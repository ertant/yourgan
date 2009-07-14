/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Xml;

namespace Yourgan.Parser
{
    public class TreeConstructionState
    {
        public TreeConstructionState(TagTokenizerState tagTokenizer, XmlDocument document)
        {
            this.tagTokenizer = tagTokenizer;
            this.document = document;
            this.tagTokenizer = tagTokenizer;
            this.handler = TreeConstruction.Initial;
        }

        TagTokenizerState tagTokenizer;

        public TagTokenizerState TagTokenizer
        {
            get
            {
                return tagTokenizer;
            }
        }

        public bool ScriptingEnabled
        {
            get
            {
                return false;
            }
        }

        bool frameSetEnabled = true;

        public bool FrameSetEnabled
        {
            get
            {
                return frameSetEnabled;
            }
            set
            {
                frameSetEnabled = value;
            }
        }

        XmlDocument document;

        public XmlDocument Document
        {
            get
            {
                return document;
            }
        }

        #region Active Formatting Elements

        FormattingElementCollection formattingElements = new FormattingElementCollection();

        public FormattingElementCollection ActiveFormattingElements
        {
            get
            {
                return formattingElements;
            }
        }

        public void ReconstructActiveFormattingElements()
        {
            // TODO : Implement
        }

        #endregion

        #region Tainted Elements

        List<XmlElement> taintedElements;

        public void MarkAsTainted()
        {
            if (current == null)
                throw new InvalidOperationException();

            if (taintedElements == null)
                taintedElements = new List<XmlElement>();

            taintedElements.Add(current);
        }

        public bool IsCurrentTableTainted()
        {
            if (taintedElements != null)
            {
                foreach (XmlElement node in this.nodes)
                {
                    if (Entity.IsTag(node.LocalName, "table"))
                    {
                        return taintedElements.Contains(node);
                    }
                }
            }

            return false;
        }

        #endregion

        #region Element Stack

        Stack<XmlElement> nodes = new Stack<XmlElement>();

        public void Pop()
        {
            nodes.Pop();
            current = nodes.Peek();

            if ((current != null) && Entity.IsTag(current.LocalName, "table"))
            {
                this.fosterParent = null;
            }
        }

        public void Push(XmlElement node)
        {
            if (node == null)
                throw new ArgumentNullException("node");

            nodes.Push(node);

            current = node;
        }

        public Stack<XmlElement> GetStack()
        {
            // create a new copy stack of current
            XmlElement[] elements = nodes.ToArray();

            Stack<XmlElement> newNodes = new Stack<XmlElement>();

            for (int i = elements.Length - 1; i >= 0; i--)
                newNodes.Push(elements[i]);

            return newNodes;
        }

        XmlElement current;

        public XmlElement Current
        {
            get
            {
                return current;
            }
        }

        public bool IsCurrentOneOfTag(params string[] tags)
        {
            return IsCurrentOneOfTagWithException(null, tags);
        }

        public bool IsCurrentOneOfTagWithException(string exceptTag, params string[] tags)
        {
            if (current != null)
            {
                foreach (string tagName in tags)
                {
                    if (!Entity.IsTag(tagName, exceptTag))
                    {
                        if (Entity.IsTag(this.Current.LocalName, tagName))
                            return true;
                    }
                }
            }

            return false;
        }

        public bool IsInStack(params string[] tagNames)
        {
            foreach (XmlElement node in this.nodes)
            {
                foreach (string tagName in tagNames)
                {
                    if (Entity.IsTag(node.LocalName, tagName))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool IsInTableScopeStack(params string[] tagNames)
        {
            foreach (string tagName in tagNames)
            {
                foreach (XmlElement node in this.nodes)
                {
                    if (Entity.IsTag(node.LocalName, tagName))
                    {
                        return true;
                    }
                    else if (Entity.IsTag(node.LocalName, "html") ||
                        Entity.IsTag(node.LocalName, "table"))
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        public void CloseInTableScope()
        {
            while (!Entity.IsTag(current.LocalName, "tbody") && !Entity.IsTag(current.LocalName, "tfoot") && !Entity.IsTag(current.LocalName, "thead") && !Entity.IsTag(current.LocalName, "html"))
            {
                this.Pop();
            }
        }

        public void CloseInTableRowScope()
        {
            while (!Entity.IsTag(current.LocalName, "tr") && !Entity.IsTag(current.LocalName, "html"))
            {
                this.Pop();
            }
        }

        public bool CloseInStack(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                throw new ArgumentNullException("tagName");

            int count = 0;
            bool found = false;

            foreach (XmlElement node in this.nodes)
            {
                if (!Entity.IsTag(node.LocalName, tagName))
                {
                    count++;
                }
                else
                {
                    found = true;
                    break;
                }
            }

            if (found)
            {
                for (int i = 0; i < count; i++)
                {
                    this.Pop();
                }

                this.Pop();
            }

            return found;
        }

        public void CloseTag(string tagName)
        {
            if (string.IsNullOrEmpty(tagName))
                throw new ArgumentNullException("tagName");

            // Generate implied end tags, except for elements with the same tag name as the token. 
            this.CloseImpliedTags(tagName);

            // HACK : Looks like HTML5 Spec is missing the <div><a><img/></a></div> situation here.
            if (!Entity.IsSpecialTag(tagName))
            {
                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                if (!this.IsCurrentOneOfTag(tagName))
                {
                    this.SetError(EntityErrorCode.UnexpectedEndTag, null);
                }
            }

            // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
            this.CloseInStack(tagName);
        }

        public void CloseImpliedTags()
        {
            CloseImpliedTags(null);
        }

        public void CloseImpliedTags(string exceptTag)
        {
            // When the steps below require the UA to generate implied end tags, then, 
            // while the current node is a dd element, a dt element, an li element, an option element, an optgroup element, a p element, 
            // an rp element, or an rt element, the UA must pop the current node off the stack of open elements.
            while (this.IsCurrentOneOfTagWithException(exceptTag, "dd", "dt", "li", "option", "optgroup", "p", "rp", "rt"))
            {
                this.Pop();
            }
        }

        #endregion

        XmlElement html;

        public XmlElement Html
        {
            get
            {
                return html;
            }
            set
            {
                html = value;
            }
        }

        XmlElement head;

        public XmlElement Head
        {
            get
            {
                return head;
            }
            set
            {
                head = value;
            }
        }

        XmlElement body;

        public XmlElement Body
        {
            get
            {
                return body;
            }
            set
            {
                body = value;
            }
        }

        XmlElement form;

        public XmlElement Form
        {
            get
            {
                return form;
            }
            set
            {
                form = value;
            }
        }

        XmlElement fosterParent;

        public XmlElement FosterParent
        {
            get
            {
                return fosterParent;
            }
        }

        public XmlElement CreateElement(string tagName, string namespaceURI)
        {
            if (string.IsNullOrEmpty(tagName))
                throw new ArgumentNullException("tagName");

            XmlElement element = document.CreateElement(tagName, namespaceURI);

            if (current != null)
            {
                // check current node was marked as tainted ?
                if ((taintedElements != null) && (current != null) && (taintedElements.Contains(current)))
                {
                    // use foster parent instead of current.
                    XmlNode fosterParent = current.ParentNode;

                    fosterParent.AppendChild(element);
                }
                else
                {
                    // append to current
                    current.AppendChild(element);
                }
            }
            else
            {
                document.AppendChild(element);
            }

            return element;
        }

        public XmlElement CreateElement(Entity entity, string namespaceURI)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            XmlElement element = CreateElement(entity.Data, namespaceURI);

            foreach (KeyValuePair<string, string> pair in entity.Attributes)
            {
                element.SetAttribute(pair.Key, pair.Value);
            }

            return element;
        }

        public XmlElement CreatePushElement(string tagName, string namespaceURI)
        {
            XmlElement element = CreateElement(tagName, namespaceURI);

            Push(element);

            return element;
        }

        public XmlElement CreatePushElement(Entity entity, string namespaceURI)
        {
            XmlElement element = CreateElement(entity, namespaceURI);

            Push(element);

            return element;
        }

        public void AppendCommentToCurrent(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            XmlComment comment = this.document.CreateComment(entity.Data);

            this.current.AppendChild(comment);
        }

        public void AppendCommentToDocument(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            XmlComment comment = this.document.CreateComment(entity.Data);

            this.document.AppendChild(comment);
        }

        public void AppendWhitespaceToCurrent(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Current.AppendChild(this.Document.CreateTextNode(entity.Data));
        }

        public void AppendDataToCurrent(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            this.Current.AppendChild(this.Document.CreateTextNode(entity.Data));
        }

        ProcessEntityHandler handler;

        bool repeat;

        public void Repeat()
        {
            repeat = true;
        }

        ProcessEntityHandler originalHandler;

        public void Switch(ProcessEntityHandler newHandler)
        {
            this.originalHandler = this.handler;

            this.handler = newHandler;
        }

        public void RevertMode()
        {
            this.handler = this.originalHandler;
        }

        public void Emit(Entity entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            do
            {
                repeat = false;

                if (handler == null)
                    throw new ParseException();
#if(LOG)
                System.Diagnostics.Debug.WriteLine("Executing : " + handler.Method.Name);
#endif
                this.handler(entity, this);
            }
            while (repeat);
        }

        public void SetError(EntityErrorCode code, Entity entity)
        {
            if (EntityError != null)
            {
                EntityError(this, new EntityErrorEventArgs(code, entity));
            }
#if(LOG)
            else
            {
                System.Diagnostics.Debug.WriteLine("Parse error : " + code.ToString() + " Entity : " + entity);
            }
#endif
        }

        public event EventHandler<EntityErrorEventArgs> EntityError;
    }
}
