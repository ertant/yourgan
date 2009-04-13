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
using System.Text;
using System.Xml;

namespace Yourgan.Parser
{
    public class TreeConstruction
    {
        static TreeConstruction()
        {
            Initial = _Initial;
            BeforeHtml = _BeforeHtml;
            BeforeHead = _BeforeHead;
            InHead = _InHead;
            InHeadNoScript = _InHeadNoScript;
            AfterHead = _AfterHead;
            InBody = _InBody;
            InCDataRCData = _InCDataRCData;
            InTable = _InTable;
            InCaption = _InCaption;
            InColumnGroup = _InColumnGroup;
            InTableBody = _InTableBody;
            InRow = _InRow;
            InCell = _InCell;
            InSelect = _InSelect;
            InSelectInTable = _InSelectInTable;
            AfterBody = _AfterBody;
            AfterAfterBody = _AfterAfterBody;
        }

        public readonly static ProcessEntityHandler Initial;
        private readonly static ProcessEntityHandler BeforeHtml;
        private readonly static ProcessEntityHandler BeforeHead;
        private readonly static ProcessEntityHandler InHead;
        private readonly static ProcessEntityHandler InHeadNoScript;
        private readonly static ProcessEntityHandler AfterHead;
        private readonly static ProcessEntityHandler InBody;
        private readonly static ProcessEntityHandler InCDataRCData;
        private readonly static ProcessEntityHandler InTable;
        private readonly static ProcessEntityHandler InCaption;
        private readonly static ProcessEntityHandler InColumnGroup;
        private readonly static ProcessEntityHandler InTableBody;
        private readonly static ProcessEntityHandler InRow;
        private readonly static ProcessEntityHandler InCell;
        private readonly static ProcessEntityHandler InSelect;
        private readonly static ProcessEntityHandler InSelectInTable;
        private readonly static ProcessEntityHandler InForeignContent;
        private readonly static ProcessEntityHandler AfterBody;
        private readonly static ProcessEntityHandler InFrameset;
        private readonly static ProcessEntityHandler AfterFrameset;
        private readonly static ProcessEntityHandler AfterAfterBody;
        private readonly static ProcessEntityHandler AfterAfterFrameset;

        private static void DataParse(TreeConstructionState state, Entity entity, ContentModelType model)
        {
            state.CreatePushElement(entity, StdNamespaces.HTML);
            state.TagTokenizer.ContentModel = model;
            state.Switch(InCDataRCData);
        }

        private static void _Initial(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                // A comment token
                case EntityType.Comment:
                    {
                        // Append a Comment node to the Document  object with the data attribute set to the data given in the comment token.
                        state.AppendCommentToDocument(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        XmlDocumentType docType = state.Document.CreateDocumentType(entity.Data, entity.Data1, entity.Data2, null);
                        state.Document.AppendChild(docType);
                        state.Switch(BeforeHtml);
                        break;
                    }
                // A character token that is one of U+0009 CHARACTER TABULATION, U+000A LINE FEED (LF), U+000C FORM FEED (FF),  or U+0020 SPACE
                case EntityType.WhiteSpace:
                    {
                        // Ignore the token.
                        break;
                    }
                // Anything else
                default:
                    {
                        // Switch the insertion mode to "before html", then reprocess the current token.
                        state.Switch(BeforeHtml);
                        state.Repeat();
                        break;
                    }
            }
        }

        private static void _BeforeHtml(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the Document  object with the data attribute set to the data given in the comment token.
                        state.AppendCommentToDocument(entity);
                        break;
                    }
                case EntityType.WhiteSpace:
                    {
                        // Ignore the token.
                        break;
                    }
                case EntityType.CloseElement:
                case EntityType.OpenElement:
                    {
                        // TODO : cache algorithm filan yaziyor burda ama anlamadim sonra bakarim.

                        if (entity.IsTag("html"))
                        {
                            // Create an element for the token in the HTML namespace. Append it to the Document  object. Put this element in the stack of open elements.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        else
                        {
                            // Create an html element. Append it to the Document object. Put this element in the stack of open elements.
                            state.CreatePushElement("html", StdNamespaces.HTML);

                            // reprocess the current token.
                            state.Repeat();
                        }

                        // Switch the insertion mode to "before head"
                        state.Switch(BeforeHead);

                        break;
                    }
            }
        }

        private static void _BeforeHeadAnythingElse(TreeConstructionState state)
        {
            // Act as if a start tag token with the tag name "head" and no attributes had been seen, then reprocess the current token.
            XmlElement head = state.CreatePushElement("head", StdNamespaces.HTML);
            state.Head = head;
            state.Switch(InHead);
            state.Repeat();
        }

        private static void _BeforeHead(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // Ignore the token.
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html" 
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        // A start tag whose tag name is "head" 
                        else if (entity.IsTag("head"))
                        {
                            // Insert an HTML element for the token.
                            XmlElement head = state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Set the head element pointer to the newly created head  element.
                            state.Head = head;

                            //Switch the insertion mode to "in head".
                            state.Switch(InHead);
                        }
                        //Anything else 
                        else
                        {
                            _BeforeHeadAnythingElse(state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is one of: "head", "br" 
                        if (entity.IsOneOfTag("head", "br"))
                        {
                            // Act as if a start tag token with the tag name "head" and no attributes had been seen, then reprocess the current token.
                            XmlElement head = state.CreatePushElement("head", StdNamespaces.HTML);

                            state.Head = head;

                            state.Switch(InHead);

                            state.Repeat();
                        }
                        // Any other end tag 
                        else
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        break;
                    }
                //Anything else 
                default:
                    {
                        _BeforeHeadAnythingElse(state);
                        break;
                    }
            }
        }

        private static void _InHeadAnythingElse(TreeConstructionState state)
        {
            // Act as if an end tag token with the tag name "head" had been seen, and reprocess the current token.
            state.CloseInStack("head");
            state.Switch(AfterHead);
            state.Repeat();
        }

        private static void _InHead(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // Insert the character  into the current node.
                        state.AppendWhitespaceToCurrent(entity);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html" 
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        // A start tag whose tag name is one of: "base", "command", "event-source", "link" 
                        else if (entity.IsOneOfTag("base", "command", "eventsource", "link"))
                        {
                            // Insert an HTML element for the token. Immediately pop the current node off the stack of open elements.
                            state.CreateElement(entity, StdNamespaces.HTML);

                            // Acknowledge the token's self-closing flag, if it is set.
                            if (!entity.IsSelfClosed)
                                state.SetError(EntityErrorCode.TagIsNotSelfClosed, entity);
                        }
                        // A start tag whose tag name is "meta" 
                        else if (entity.IsTag("meta"))
                        {
                            // Insert an HTML element for the token. Immediately pop the current node off the stack of open elements.
                            state.CreateElement(entity, StdNamespaces.HTML);

                            // Acknowledge the token's self-closing flag, if it is set.
                            if (!entity.IsSelfClosed)
                                state.SetError(EntityErrorCode.TagIsNotSelfClosed, entity);

                            // TODO : If the element has a charset  attribute, and its value is a supported encoding, and the confidence is currently tentative, 
                            // then change the encoding to the encoding given by the value of the charset  attribute.

                            // TODO : Otherwise, if the element has a content attribute, and applying the algorithm for extracting an encoding 
                            // from a Content-Type to its value returns a supported encoding encoding, and the confidence is currently tentative, 
                            // then change the encoding to the encoding encoding.
                        }
                        // A start tag whose tag name is "title" 
                        else if (entity.IsTag("title"))
                        {
                            // Follow the generic RCDATA parsing algorithm.
                            DataParse(state, entity, ContentModelType.RCData);
                        }
                        // A start tag whose tag name is "noscript", if the scripting flag is enabled 
                        else if (entity.IsTag("noscript") && state.ScriptingEnabled)
                        {
                            // Follow the generic CDATA parsing algorithm.
                            DataParse(state, entity, ContentModelType.CData);
                        }
                        // A start tag whose tag name is one of: "noframes", "style" 
                        else if (entity.IsTag("noframes") || entity.IsTag("style"))
                        {
                            // Follow the generic CDATA parsing algorithm.
                            DataParse(state, entity, ContentModelType.CData);
                        }
                        // A start tag whose tag name is "noscript", if the scripting flag is disabled 
                        else if (entity.IsTag("noscript") && !state.ScriptingEnabled)
                        {
                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Switch the insertion mode to "in head noscript".
                            state.Switch(InHeadNoScript);
                        }
                        // A start tag whose tag name is "script" 
                        else if (entity.IsTag("script"))
                        {
                            // TODO : script implement
                            XmlElement script = state.CreatePushElement(entity, StdNamespaces.HTML);
                            state.Switch(InCDataRCData);
                        }
                        // A start tag whose tag name is "head" 
                        else if (entity.IsTag("head"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.HeadUnexpected, entity);
                        }
                        // Anything else 
                        else
                        {
                            _InHeadAnythingElse(state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "head" 
                        if (entity.IsTag("head"))
                        {
                            // Pop the current node (which will be the head element) off the stack of open elements.
                            state.Pop();

                            // Switch the insertion mode to "after head".
                            state.Switch(AfterHead);
                        }
                        // An end tag whose tag name is "br" 
                        else if (entity.IsTag("br"))
                        {
                            // Act as described in the "anything else" entry below.
                            _InHeadAnythingElse(state);
                        }
                        // Any other end tag 
                        else
                        {
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }

                        break;
                    }
                default:
                    {
                        // Act as if an end tag token with the tag name "head" had been seen, and reprocess the current token.
                        state.Pop();
                        state.Switch(InBody);
                        state.Repeat();
                        break;
                    }
            }
        }

        private static void _InHeadNoScript(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.DOCType:
                    {
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.WhiteSpace:
                    {
                        // Process the token using the rules for the "in head" insertion mode.
                        _InHead(entity, state);
                        break;
                    }
                // A comment token 
                case EntityType.Comment:
                    {
                        // Process the token using the rules for the "in head" insertion mode.
                        _InHead(entity, state);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        //A start tag whose tag name is one of: "link", "meta", "noframes", "style"
                        else if (entity.IsOneOfTag("link", "meta", "noframes", "style"))
                        {
                            // Process the token using the rules for the "in head" insertion mode.
                            _InHead(entity, state);
                        }
                        // A start tag whose tag name is one of: "head", "noscript"
                        else if (entity.IsOneOfTag("head", "noscript"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                        }
                        // Anything else
                        else
                        {
                            _InHeadAnythingElse(state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        //An end tag whose tag name is "noscript"
                        if (entity.IsTag("noscript"))
                        {
                            // Pop the current node (which will be a noscript element) from the stack of open elements; the new current node will be a head element.
                            state.Pop();

                            // Switch the insertion mode to "in head".
                            state.Switch(InHead);
                        }
                        // An end tag whose tag name is "br"
                        else if (entity.IsTag("br"))
                        {
                            // Act as described in the "anything else" entry below.
                            _InHeadAnythingElse(state);
                        }
                        // Any other end tag
                        else
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }

                        break;
                    }
            }
        }

        private static void _AfterHeadAnythingElse(TreeConstructionState state)
        {
            // Act as if a start tag token with the tag name "body" and no attributes had been seen, and then reprocess the current token.
            XmlElement body = state.CreatePushElement("body", StdNamespaces.HTML);

            state.Body = body;

            state.Switch(InBody);

            state.Repeat();
        }

        private static void _AfterHead(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // A character token that is one of U+0009 CHARACTER TABULATION, U+000A LINE FEED (LF), U+000C FORM FEED (FF),  or U+0020 SPACE
                        // Insert the character into the current node.
                        state.AppendWhitespaceToCurrent(entity);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            _InBody(entity, state);
                        }
                        // A start tag whose tag name is "body"
                        else if (entity.IsTag("body"))
                        {
                            // Insert an HTML element for the token.
                            XmlElement body = state.CreatePushElement(entity, StdNamespaces.HTML);

                            state.Body = body;

                            // Switch the insertion mode to "in body".
                            state.Switch(InBody);
                        }
                        // A start tag whose tag name is "frameset"
                        else if (entity.IsTag("frameset"))
                        {
                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Switch the insertion mode to "in frameset".
                            state.Switch(InFrameset);
                        }
                        // A start tag token whose tag name is one of: "base", "link", "meta", "noframes", "script", "style", "title"
                        else if (entity.IsOneOfTag("base", "link", "meta", "noframes", "script", "style", "title"))
                        {
                            //Parse error.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            //Push the node pointed to by the head element pointer onto the stack of open elements.
                            state.Push(state.Head);

                            //Process the token using the rules for the "in head" insertion mode.
                            _InHead(entity, state);

                            //Remove the node pointed to by the head element pointer from the stack of open elements.
                            state.Pop();
                        }
                        // A start tag whose tag name is "head"
                        else if (entity.IsTag("head"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                        }
                        else
                        {
                            // Anything else
                            _AfterHeadAnythingElse(state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "br"
                        if (entity.IsTag("br"))
                        {
                            // Act as described in the "anything else" entry below.
                            _AfterHeadAnythingElse(state);
                        }
                        else
                        {
                            // Any other end tag
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }

                        break;
                    }
                default:
                    {
                        // Anything else
                        _AfterHeadAnythingElse(state);
                        break;
                    }
            }
        }

        private static void _InBody(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                // A character token
                case EntityType.Data:
                    {
                        //Reconstruct the active formatting elements, if any.
                        state.ReconstructActiveFormattingElements();
                        //Insert the token's character into the current node.
                        //If the token is not one of U+0009 CHARACTER TABULATION, U+000A LINE FEED (LF), U+000C FORM FEED (FF), or U+0020 SPACE, then set the frameset-ok flag to "not ok".
                        state.Current.AppendChild(state.Document.CreateTextNode(entity.Data));
                        // TODO : ?
                        break;
                    }
                case EntityType.Comment:
                    {
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // Parse error. 
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            // For each attribute on the token, check to see if the attribute is already present on the top element of the stack of open elements. If it is not, add the attribute and its corresponding value to that element.
                            // TODO : implement
                        }
                        // A start tag token whose tag name is one of: "base", "command", "eventsource", "link", "meta", "noframes", "script", "style", "title"
                        else if (entity.IsOneOfTag("base", "command", "eventsource", "link", "meta", "noframes", "script", "style", "title"))
                        {
                            // Process the token using the rules for the "in head" insertion mode.
                            _InHead(entity, state);
                        }
                        // A start tag whose tag name is "body"
                        else if (entity.IsTag("body"))
                        {
                            // Parse error.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            // If the second element on the stack of open elements is not a body element, or, if the stack of open elements has only one node on it, then ignore the token. (fragment case)
                            // TODO : implement

                            // Otherwise, for each attribute on the token, check to see if the attribute is already present on the body element (the second element) on the stack of open elements. If it is not, add the attribute and its corresponding value to that element.
                            // TODO : implement
                        }
                        // A start tag whose tag name is "frameset"
                        else if (entity.IsTag("frameset"))
                        {
                            // TODO : implement
                        }
                        // A start tag whose tag name is one of: "address", "article", "aside", "blockquote", "center", "datagrid", "details", "dialog", "dir", "div", "dl", "fieldset", "figure", "footer", "header", "menu", "nav", "ol", "p", "section", "ul"
                        else if (entity.IsOneOfTag("address", "article", "aside", "blockquote", "center", "datagrid", "details", "dialog", "dir", "div", "dl", "fieldset", "figure", "footer", "header", "menu", "nav", "ol", "p", "section", "ul"))
                        {
                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        // A start tag whose tag name is one of: "h1", "h2", "h3", "h4", "h5", "h6"
                        else if (entity.IsOneOfTag("h1", "h2", "h3", "h4", "h5", "h6"))
                        {
                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            // If the current node is an element whose tag name is one of "h1", "h2", "h3", "h4", "h5", or "h6", then this is a parse error; pop the current node off the stack of open elements.
                            if (state.IsCurrentOneOfTag("h1", "h2", "h3", "h4", "h5", "h6"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                                state.Pop();
                            }

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        // start tag whose tag name is one of: "pre", "listing"
                        else if (entity.IsOneOfTag("pre", "listing"))
                        {
                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // If the next token is a U+000A LINE FEED (LF) character token, then ignore that token and move on to the next one. (Newlines at the start of pre blocks are ignored as an authoring convenience.)
                            // TODO : implement

                            // Set the frameset-ok flag to "not ok".
                            state.FrameSetEnabled = false;
                        }
                        // A start tag whose tag name is "form"
                        else if (entity.IsTag("form"))
                        {
                            // If the form element pointer is not null, then this is a parse error; ignore the token.
                            if (state.Form != null)
                            {
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            }
                            // Otherwise:
                            else
                            {
                                // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                                state.CloseInStack("p");

                                // Insert an HTML element for the token, and set the form element pointer to point to the element created.
                                state.CreatePushElement(entity, StdNamespaces.HTML);
                            }
                        }
                        // A start tag whose tag name is "li"
                        else if (entity.IsTag("li"))
                        {
                            // Spec'de algorithm calistirilacak yaziyor. simdilik iptal.
                            // TODO : imlement

                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            // Finally, insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        // A start tag whose tag name is one of: "dd", "dt"
                        else if (entity.IsOneOfTag("dd", "dt"))
                        {
                            // toptan iptal simdilik.
                            // TODO : implement
                        }
                        else if (entity.IsTag("plaintext"))
                        {
                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Switch the content model flag to the PLAINTEXT state.
                            // TODO : 
                        }
                        // A start tag whose tag name is "a" 
                        else if (entity.IsTag("a"))
                        {
                            // If the list of active formatting elements  contains an element whose tag name is "a" between the end of the list and 
                            // the last marker on the list (or the start of the list if there is no marker on the list), 
                            // then this is a parse error; act as if an end tag with the tag name "a" had been seen, 
                            // then remove that element from the list of active formatting elements and the stack of open elements if the end tag didn't 
                            // already remove it (it might not have if the element is not in table scope).
                            // TODO : implement

                            // Reconstruct the active formatting elements, if any.
                            state.ReconstructActiveFormattingElements();

                            // Insert an HTML element for the token. 
                            XmlElement element = state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Add that element to the list of active formatting elements.
                            state.ActiveFormattingElements.Push(element);
                        }
                        // A start tag whose tag name is one of: "b", "big", "em", "font", "i", "s", "small", "strike", "strong", "tt", "u" 
                        else if (entity.IsOneOfTag("b", "big", "em", "font", "i", "s", "small", "strike", "strong", "tt", "u"))
                        {
                            // Reconstruct the active formatting elements, if any.
                            state.ReconstructActiveFormattingElements();

                            // Insert an HTML element for the token.
                            XmlElement element = state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Add that element to the list of active formatting elements.
                            state.ActiveFormattingElements.Push(element);
                        }
                        // A start tag whose tag name is "nobr" 
                        else if (entity.IsTag("nobr"))
                        {
                            // Reconstruct the active formatting elements, if any.
                            state.ReconstructActiveFormattingElements();

                            // If the stack of open elements has a nobr element in scope, then this is a parse error. 
                            // Act as if an end tag with the tag name nobr had been seen, then once again reconstruct the active formatting elements, if any.
                            if (state.IsInStack("nobr"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                                state.CloseInStack("nobr");
                                state.ReconstructActiveFormattingElements();
                            }

                            // Insert an HTML element for the token. 
                            XmlElement element = state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Add that element to the list of active formatting elements.
                            state.ActiveFormattingElements.Push(element);
                        }
                        // A start tag whose tag name is "button" 
                        else if (entity.IsTag("button"))
                        {
                            // TODO : implement
                        }
                        // A start tag token whose tag name is one of: "applet", "marquee", "object" 
                        else if (entity.IsOneOfTag("applet", "marquee", "object"))
                        {
                            // Reconstruct the active formatting elements, if any.
                            state.ReconstructActiveFormattingElements();

                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Insert a marker at the end of the list of active formatting elements.                        
                            state.ActiveFormattingElements.PushMarker();

                            // Set the frameset-ok flag to "not ok".
                            state.FrameSetEnabled = false;
                        }
                        // A start tag whose tag name is "table" 
                        else if (entity.IsTag("table"))
                        {
                            // If the stack of open elements has a p element in scope, then act as if an end tag with the tag name "p" had been seen.
                            state.CloseInStack("p");

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            // Set the frameset-ok flag to "not ok".
                            state.FrameSetEnabled = false;

                            // Switch the insertion mode to "in table".
                            state.Switch(InTable);
                        }
                        // Any other start tag 
                        else
                        {
                            // Reconstruct the active formatting elements, if any
                            state.ReconstructActiveFormattingElements();

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, "");
                        }

                        // A start tag whose tag name is one of: "area", "basefont", "bgsound", "br", "embed", "img", "input", "spacer", "wbr"
                        // A start tag whose tag name is one of: "param", "source" 
                        // A start tag whose tag name is "hr" 
                        // A start tag whose tag name is "image" 
                        // A start tag whose tag name is "isindex" 
                        // A start tag whose tag name is "textarea" 
                        // A start tag whose tag name is "xmp"
                        // A start tag whose tag name is "iframe"
                        // A start tag whose tag name is "noembed"
                        // A start tag whose tag name is "noscript", if the scripting flag is enabled
                        // A start tag whose tag name is "select"
                        // A start tag whose tag name is one of: "optgroup", "option"
                        // A start tag whose tag name is one of: "rp", "rt"
                        // An end tag whose tag name is "br"
                        // A start tag whose tag name is "math"
                        // A start  tag whose tag name is one of: "caption", "col", "colgroup", "frame", "head", "tbody", "td", "tfoot", "th", "thead", "tr"

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "body"
                        if (entity.IsTag("body"))
                        {
                            // If the stack of open elements does not have a body element in scope, this is a parse error; ignore the token.
                            if (state.Body == null)
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise, 
                            else
                            {
                                // if there is a node in the stack of open elements that is not either a dd element, a dt element, an li element, 
                                // a p element, a tbody element, a td element, a tfoot element, a th element, a thead element, a tr element, the body element, 
                                // or the html element, then this is a parse error.
                                if (!state.IsInStack("dd", "dt", "li", "p", "tbody", "td", "tfoot", "th", "thead", "tr", "body", "html"))
                                {
                                    state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                }

                                // Switch the insertion mode to "after body".
                                state.Switch(AfterBody);
                            }
                        }
                        // An end tag whose tag name is "html"
                        else if (entity.IsTag("html"))
                        {
                            // Act as if an end tag with tag name "body" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            if (state.CloseInStack("body"))
                            {
                                state.Repeat();
                            }
                        }
                        // An end tag whose tag name is one of: "address", "article", "aside", "blockquote", "center", "datagrid", "details", "dialog", "dir", "div", "dl", "fieldset", "figure", "footer", "header", "listing", "menu", "nav", "ol", "pre", "section", "ul"
                        else if (entity.IsOneOfTag("address", "article", "aside", "blockquote", "center", "datagrid", "details", "dialog", "dir", "div", "dl", "fieldset", "figure", "footer", "header", "listing", "menu", "nav", "ol", "pre", "section", "ul"))
                        {
                            // If the stack of open elements does not have an element in scope  with the same tag name as that of the token, then this is a parse error; ignore the token
                            if (!state.IsInStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                // Generate implied end tags, except for elements with the same tag name as the token. 
                                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                                // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
                                state.CloseTag(entity.Data);
                            }
                        }
                        // An end tag whose tag name is "form"
                        else if (entity.IsTag("form"))
                        {
                            // Let node be the element that the form element pointer is set to.
                            XmlElement formElement = state.Form;

                            // Set the form element pointer  to null.
                            state.Form = null;

                            // If node is null or the stack of open elements does not have node in scope, then this is a parse error; ignore the token.
                            if (formElement == null || (state.Current == null))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                // Generate implied end tags. 
                                state.CloseImpliedTags();

                                // If the current node is not node, then this is a parse error. 
                                if (state.Current != formElement)
                                {
                                    state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                }
                                else
                                {
                                    // Remove node from the stack of open elements. 
                                    state.Pop();
                                }
                            }
                        }
                        // An end tag whose tag name is "p"
                        else if (entity.IsTag("p"))
                        {
                            // If the stack of open elements does not have an element in scope  with the same tag name as that of the token, 
                            // then this is a parse error; act as if a start tag with the tag name "p" had been seen, then reprocess the current token.
                            if (!state.IsInStack("p"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                state.CreatePushElement("p", StdNamespaces.HTML);
                                state.Repeat();
                            }
                            else
                            {
                                // Generate implied end tags, except for elements with the same tag name as the token. 
                                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                                // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
                                state.CloseTag(entity.Data);
                            }
                        }
                        // An end tag whose tag name is one of: "dd", "dt", "li"
                        else if (entity.IsOneOfTag("dd", "dt", "li"))
                        {
                            // If the stack of open elements does not have an element in scope  with the same tag name as that of the token, then this is a parse error; ignore the token
                            if (!state.IsInStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise,
                            else
                            {
                                // Generate implied end tags, except for elements with the same tag name as the token. 
                                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                                // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
                                state.CloseTag(entity.Data);
                            }
                        }
                        // An end tag whose tag name is one of: "h1", "h2", "h3", "h4", "h5", "h6"
                        else if (entity.IsOneOfTag("h1", "h2", "h3", "h4", "h5", "h6"))
                        {
                            // If the stack of open elements does not have an element in scope  whose tag name is one of "h1", "h2", "h3", "h4", "h5", or "h6", then this is a parse error; ignore the token
                            if (!state.IsInStack("h1", "h2", "h3", "h4", "h5", "h6"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise,
                            else
                            {
                                // Generate implied end tags, except for elements with the same tag name as the token. 
                                state.CloseImpliedTags(entity.Data);

                                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                                if (!state.IsCurrentOneOfTag(entity.Data))
                                {
                                    state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                }

                                // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
                                while (!state.IsCurrentOneOfTag("h1", "h2", "h3", "h4", "h5", "h6"))
                                {
                                    state.Pop();
                                }
                            }
                        }
                        // An end tag whose tag name is one of: "a", "b", "big", "em", "font", "i", "nobr", "s", "small", "strike", "strong", "tt", "u"
                        else if (entity.IsOneOfTag("a", "b", "big", "em", "font", "i", "nobr", "s", "small", "strike", "strong", "tt", "u"))
                        {
                            // TODO : implement
                        }
                        // A end tag token whose tag name is one of: "applet", "marquee", "object" 
                        else if (entity.IsOneOfTag("applet", "marquee", "object"))
                        {
                            // If the stack of open elements does not have an element in scope with the same tag name as that of the token, then this is a parse error.
                            if (!state.IsInStack("applet", "marquee", "object"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise,
                            else
                            {
                                // Generate implied end tags. 
                                // If the current node is not an element with the same tag name as that of the token, then this is a parse error. 
                                // Pop elements from the stack of open elements  until an element with the same tag name as the token has been popped from the stack. 
                                state.CloseTag(entity.Data);

                                // TODO : Clear the list of active formatting elements up to the last marker. 
                            }
                        }
                        // Any other end tag 
                        else
                        {
                            Stack<XmlElement> nodeStack = state.GetStack();

                            // Initialise node to be the current node (the bottommost node of the stack). 
                            XmlElement node = nodeStack.Peek();

                            while (true)
                            {
                                // If node has the same tag name as the end tag token, then
                                if (entity.IsTag(node.LocalName))
                                {
                                    // Generate implied end tags. 
                                    state.CloseImpliedTags();

                                    // If the tag name of the end tag token does not match the tag name of the current node, this is a parse error. 
                                    if (!entity.IsTag(node.LocalName))
                                    {
                                        state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                    }

                                    // Pop all the nodes from the current node up to node, including node, then stop this algorithm. 
                                    while (state.Current != node)
                                    {
                                        state.Pop();
                                    }

                                    break;
                                }
                                // Otherwise,
                                else
                                {
                                    // HACK : HTML5 Spec missing the map/area tags here.
                                    if (!Entity.IsSpecialTag(node.LocalName))
                                    {
                                        // if node is in neither the formatting category nor the phrasing category, then this is a parse error. 
                                        // Stop this algorithm. The end tag token is ignored
                                        if (!Entity.IsFormattingTag(node.LocalName) &&
                                            !Entity.IsPhrasingTag(node.LocalName))
                                        {
                                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                            break;
                                        }
                                    }

                                    // Set node to the previous entry in the stack of open elements.
                                    node = nodeStack.Pop();
                                }
                            }
                        }

                        break;
                    }

            }
        }

        private static void _InCDataRCData(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                // A character token
                case EntityType.Data:
                    {
                        state.Current.AppendChild(state.Document.CreateTextNode(entity.Data));
                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "script"
                        if (entity.IsTag("script"))
                        {
                            // TODO :  
                        }
                        // Any other end tag
                        else
                        {
                            // Pop the current node off the stack of open elements.
                            state.Pop();
                            // Switch the insertion mode to the original insertion mode.
                            state.RevertMode();
                        }
                        break;
                    }
            }
        }

        private static void _InTableAnythingElse(Entity entity, TreeConstructionState state)
        {
            // Parse error. 
            state.SetError(EntityErrorCode.UnexpectedTag, entity);

            // Process the token using the rules for the "in body" insertion mode, 
            // except that if the current node is a table, tbody, tfoot, thead, or tr element, then, whenever a node would be inserted into the current node, 
            // it must instead be foster parented.
            if (state.IsCurrentOneOfTag("table", "tbody", "tfoot", "thead", "tr"))
            {
                state.MarkAsTainted();
            }

            _InBody(entity, state);
        }

        private static void _InTable(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // If the current table is tainted, 
                        if (state.IsCurrentTableTainted())
                        {
                            // then act as described in the "anything else" entry below.
                            _InTableAnythingElse(entity, state);
                        }
                        else
                        {
                            // Otherwise, insert the character into the current node.
                            state.AppendWhitespaceToCurrent(entity);
                        }

                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "caption"
                        if (entity.IsTag("caption"))
                        {
                            // Clear the stack back to a table context. (See below.)
                            while (!state.IsCurrentOneOfTag("table", "html"))
                                state.Pop();

                            // Insert a marker at the end of the list of active formatting elements.
                            state.ActiveFormattingElements.PushMarker();

                            // Insert an HTML element for the token, then switch the insertion mode to "in caption".
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                            state.Switch(InCaption);
                        }
                        // A start tag whose tag name is "colgroup"
                        else if (entity.IsTag("colgroup"))
                        {
                            // Clear the stack back to a table context. (See below.)
                            while (!state.IsCurrentOneOfTag("table", "html"))
                                state.Pop();

                            // Insert an HTML element for the token, then switch the insertion mode to "in column group".
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                            state.Switch(InColumnGroup);
                        }
                        // A start tag whose tag name is "col"
                        else if (entity.IsTag("col"))
                        {
                            // Act as if a start tag token with the tag name "colgroup" had been seen, then reprocess the current token.
                            state.CreatePushElement("colgroup", StdNamespaces.HTML);
                            state.Switch(InColumnGroup);
                            state.Repeat();
                        }
                        // A start tag whose tag name is one of: "tbody", "tfoot", "thead"
                        else if (entity.IsOneOfTag("tbody", "tfoot", "thead"))
                        {
                            // Clear the stack back to a table context. (See below.)
                            while (!state.IsCurrentOneOfTag("table", "html"))
                                state.Pop();

                            // Insert an HTML element for the token, then switch the insertion mode to "in table body".
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                            state.Switch(InTableBody);
                        }
                        // A start tag whose tag name is one of: "td", "th", "tr"
                        else if (entity.IsOneOfTag("td", "th", "tr"))
                        {
                            // Act as if a start tag token with the tag name "tbody" had been seen, then reprocess the current token.
                            state.CreatePushElement("tbody", StdNamespaces.HTML);
                            state.Switch(InTableBody);
                            state.Repeat();
                        }
                        // A start tag whose tag name is "table"
                        else if (entity.IsTag("table"))
                        {
                            // Parse error. Act as if an end tag token with the tag name "table" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            if (state.CloseInStack("table"))
                                state.Repeat();
                        }
                        // A start tag whose tag name is one of: "style", "script"
                        else if (entity.IsOneOfTag("style", "script"))
                        {
                            // If the current table is tainted 
                            if (state.IsCurrentTableTainted())
                            {
                                // then act as described in the "anything else" entry below.
                                _InTableAnythingElse(entity, state);
                            }
                            else
                            {
                                // Otherwise, process the token using the rules for the "in head" insertion mode.
                                _InHead(entity, state);
                            }
                        }
                        // A start tag whose tag name is "input"
                        else if (entity.IsTag("input"))
                        {
                            if (
                                // If the token does not have an attribute with the name "type", 
                                !entity.Attributes.ContainsKey("type") ||
                                // or if it does, but that attribute's value is not an ASCII case-insensitive match for the string "hidden",
                                (entity.Attributes.ContainsKey("type") && entity.Attributes["type"].Equals("hidden", StringComparison.OrdinalIgnoreCase)) ||
                                // or, if the current table is tainted, then
                                state.IsCurrentTableTainted()
                                )
                            {
                                // act as described in the "anything else" entry below.
                                _InTableAnythingElse(entity, state);
                            }
                            // Otherwise:
                            else
                            {
                                // Parse error.
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                                // Insert an HTML element for the token.
                                state.CreatePushElement(entity, StdNamespaces.HTML);

                                // Pop that input element off the stack of open elements.
                                state.Pop();
                            }
                        }
                        // Anything else
                        else
                        {
                            _InTableAnythingElse(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "table"
                        if (entity.IsTag("table"))
                        {
                            // If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise:
                            else
                            {
                                // Pop elements from this stack until a table element has been popped from the stack.
                                while (!state.IsCurrentOneOfTag("table"))
                                    state.Pop();
                            }

                            // TODO : Reset the insertion mode appropriately.
                        }
                        // An end tag whose tag name is one of: "body", "caption", "col", "colgroup", "html", "tbody", "td", "tfoot", "th", "thead", "tr"
                        else if (entity.IsOneOfTag("body", "caption", "col", "colgroup", "html", "tbody", "td", "tfoot", "th", "thead", "tr"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // Anything else
                        else
                        {
                            _InTableAnythingElse(entity, state);
                        }

                        break;
                    }
                default:
                    {
                        // Anything else
                        _InTableAnythingElse(entity, state);

                        break;
                    }
            }
        }

        private static void _InCaption(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is one of: "caption", "col", "colgroup", "tbody", "td", "tfoot", "th", "thead", "tr"
                        if (entity.IsOneOfTag("caption", "col", "colgroup", "tbody", "td", "tfoot", "th", "thead", "tr"))
                        {
                            //Parse error. Act as if an end tag with the tag name "caption" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            if (state.CloseInStack("caption"))
                                state.Repeat();
                        }
                        // Anything else
                        else
                        {
                            _InBody(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "caption"
                        if (entity.IsTag("caption"))
                        {
                            //If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack("caption"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            //Otherwise:
                            else
                            {
                                //Generate implied end tags.
                                state.CloseImpliedTags();

                                //Now, if the current node is not a caption element, then this is a parse error.
                                if (Entity.IsTag(state.Current.LocalName, "caption"))
                                    state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                else
                                    //Pop elements from this stack until a caption element has been popped from the stack.
                                    state.CloseInStack("caption");

                                //Clear the list of active formatting elements up to the last marker.
                                state.ActiveFormattingElements.ClearToMarker();

                                //Switch the insertion mode to "in table".
                                state.Switch(InTable);
                            }

                            break;
                        }
                        // An end tag whose tag name is "table"
                        else if (entity.IsTag("table"))
                        {
                            //Parse error. Act as if an end tag with the tag name "caption" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);

                            state.CloseInStack("caption");
                        }
                        // An end tag whose tag name is one of: "body", "col", "colgroup", "html", "tbody", "td", "tfoot", "th", "thead", "tr"
                        else if (entity.IsOneOfTag("body", "col", "colgroup", "html", "tbody", "td", "tfoot", "th", "thead", "tr"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        // Process the token using the rules for the "in body" insertion mode.
                        _InBody(entity, state);

                        break;
                    }
            }
        }

        private static void _InColumnGroup(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // Insert the character into the current node.
                        state.AppendWhitespaceToCurrent(entity);

                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);

                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);

                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        // A start tag whose tag name is "col"
                        else if (entity.IsTag("col"))
                        {
                            // Insert an HTML element for the token. Immediately pop the current node off the stack of open elements.
                            state.CreateElement(entity, StdNamespaces.HTML);
                            // Acknowledge the token's self-closing flag, if it is set.
                            if (!entity.IsSelfClosed)
                                state.SetError(EntityErrorCode.TagIsNotSelfClosed, entity);
                        }
                        // Anything else
                        else
                        {
                            // Act as if an end tag with the tag name "colgroup" had been seen, and then, if that token wasn't ignored, reprocess the current token.
                            if (state.CloseInStack("colgroup"))
                                state.Repeat();
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "colgroup"
                        if (entity.IsTag("colgroup"))
                        {
                            // If the current node is the root html element, then this is a parse error; ignore the token. (fragment case)
                            if (state.IsCurrentOneOfTag("html"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // An end tag whose tag name is "colgroup"
                            else if (entity.IsTag("colgroup"))
                            {
                                // Otherwise, pop the current node (which will be a colgroup element) from the stack of open elements. Switch the insertion mode to "in table".
                                state.Pop();
                                state.Switch(InTable);
                            }
                            // An end tag whose tag name is "col"
                            else if (entity.IsTag("col"))
                            {
                                // Parse error. Ignore the token.
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Anything else
                            else
                            {
                                // Act as if an end tag with the tag name "colgroup" had been seen, and then, if that token wasn't ignored, reprocess the current token.
                                if (state.CloseInStack("colgroup"))
                                    state.Repeat();
                            }
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        // Act as if an end tag with the tag name "colgroup" had been seen, and then, if that token wasn't ignored, reprocess the current token.
                        if (state.CloseInStack("colgroup"))
                            state.Repeat();

                        break;
                    }
            }
        }

        private static void _InTableBody(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "tr"
                        if (entity.IsTag("tr"))
                        {
                            // TODO : Clear the stack back to a table body context. (See below.)
                            state.CloseInTableScope();

                            // Insert an HTML element for the token, then switch the insertion mode to "in row".
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            state.Switch(InRow);
                        }
                        // A start tag whose tag name is one of: "th", "td"
                        else if (entity.IsOneOfTag("th", "td"))
                        {
                            // Parse error. Act as if a start tag with the tag name "tr" had been seen, then reprocess the current token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            state.CreatePushElement("tr", StdNamespaces.HTML);
                            state.Switch(InRow);
                            state.Repeat();
                        }
                        // A start tag whose tag name is one of: "caption", "col", "colgroup", "tbody", "tfoot", "thead"
                        else if (entity.IsOneOfTag("caption", "col", "colgroup", "tbody", "tfoot", "thead"))
                        {
                            // If the stack of open elements does not have a tbody, thead, or tfoot  element in table scope, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack("tbody", "thead", "tfoot"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            }
                            else
                            {
                                // Otherwise:
                                // Clear the stack back to a table body context. (See below.)
                                state.CloseInTableScope();

                                // Act as if an end tag with the same tag name as the current node ("tbody", "tfoot", or "thead") had been seen, then reprocess the current token.
                                state.CloseInStack(entity.Data);

                                state.Repeat();
                            }
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in table" insertion mode.
                            _InTable(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is one of: "tbody", "tfoot", "thead"
                        if (entity.IsOneOfTag("tbody", "tfoot", "thead"))
                        {
                            // If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                //Clear the stack back to a table body context. (See below.)
                                state.CloseInTableScope();

                                //Pop the current node from the stack of open elements. Switch the insertion mode  to "in table".
                                state.Pop();
                                state.Switch(InTable);
                            }
                        }
                        else if (entity.IsTag("table"))
                        {
                            // If the stack of open elements does not have a tbody, thead, or tfoot  element in table scope, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack("tbody", "thead", "tfoot"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                // Otherwise:
                                // Clear the stack back to a table body context. (See below.)
                                state.CloseInTableScope();

                                // Act as if an end tag with the same tag name as the current node ("tbody", "tfoot", or "thead") had been seen, then reprocess the current token.
                                if (state.IsInTableScopeStack("tbody"))
                                    state.CloseInStack("tbody");
                                else if (state.IsInTableScopeStack("tfoot"))
                                    state.CloseInStack("tfoot");
                                else if (state.IsInTableScopeStack("thead"))
                                    state.CloseInStack("thead");

                                state.Switch(InTable);
                                state.Repeat();
                            }
                        }
                        // An end tag whose tag name is one of: "body", "caption", "col", "colgroup", "html", "td", "th", "tr"
                        else if (entity.IsOneOfTag("body", "caption", "col", "colgroup", "html", "td", "th", "tr"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in table" insertion mode.
                            _InTable(entity, state);
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        // Process the token using the rules for the "in table" insertion mode.
                        _InTable(entity, state);

                        break;
                    }
            }
        }

        private static void _InRow(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is one of: "th", "td"
                        if (entity.IsOneOfTag("th", "td"))
                        {
                            // Clear the stack back to a table row context. (See below.)
                            state.CloseInTableRowScope();

                            // Insert an HTML element for the token, then switch the insertion mode to "in cell".
                            state.CreatePushElement(entity, StdNamespaces.HTML);

                            state.Switch(InCell);

                            // Insert a marker at the end of the list of active formatting elements.
                            state.ActiveFormattingElements.PushMarker();
                        }
                        // A start tag whose tag name is one of: "caption", "col", "colgroup", "tbody", "tfoot", "thead", "tr"
                        else if (entity.IsOneOfTag("caption", "col", "colgroup", "tbody", "tfoot", "thead", "tr"))
                        {
                            // Act as if an end tag with the tag name "tr" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            if (state.CloseInStack("tr"))
                                state.Repeat();
                        }
                        // Anything else
                        else
                        {
                            //Process the token using the rules for the "in table" insertion mode.
                            _InTable(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "tr"
                        if (entity.IsTag("tr"))
                        {
                            // If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            // Otherwise:
                            else
                            {
                                // Clear the stack back to a table row context. (See below.)
                                state.CloseInTableRowScope();

                                // Pop the current node (which will be a tr element) from the stack of open elements. Switch the insertion mode to "in table body".
                                state.Pop();

                                state.Switch(InTableBody);
                            }
                        }
                        // An end tag whose tag name is "table"
                        else if (entity.IsTag("table"))
                        {
                            // Act as if an end tag with the tag name "tr" had been seen, then, if that token wasn't ignored, reprocess the current token.
                            if (state.CloseInStack("tr"))
                                state.Repeat();
                        }
                        // An end tag whose tag name is one of: "tbody", "tfoot", "thead"
                        else if (entity.IsOneOfTag("tbody", "tfoot", "thead"))
                        {
                            // If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token.
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                // Otherwise, act as if an end tag with the tag name "tr" had been seen, then reprocess the current token.
                                if (state.CloseInStack("tr"))
                                    state.Repeat();
                            }
                        }
                        // An end tag whose tag name is one of: "body", "caption", "col", "colgroup", "html", "td", "th"
                        else if (entity.IsOneOfTag("body", "caption", "col", "colgroup", "html", "td", "th"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // Anything else
                        else
                        {
                            //Process the token using the rules for the "in table" insertion mode.
                            _InTable(entity, state);
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        //Process the token using the rules for the "in table" insertion mode.
                        _InTable(entity, state);

                        break;
                    }
            }
        }

        private static void _InCell(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is one of: "caption", "col", "colgroup", "tbody", "td", "tfoot", "th", "thead", "tr"
                        if (entity.IsOneOfTag("caption", "col", "colgroup", "tbody", "td", "tfoot", "th", "thead", "tr"))
                        {
                            //If the stack of open elements does not have a td or th element in table scope, then this is a parse error; ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack("td", "th"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            }
                            else
                            {
                                //Otherwise, close the cell (see below) and reprocess the current token
                                if (!state.CloseInStack("td"))
                                    state.CloseInStack("th");
                            }
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is one of: "td", "th"
                        if (entity.IsOneOfTag("td", "th"))
                        {
                            //If the stack of open elements does not have an element in table scope with the same tag name as that of the token, then this is a parse error and the token must be ignored.
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            //Otherwise:
                            else
                            {
                                //Generate implied end tags.
                                state.CloseImpliedTags();

                                //Now, if the current node is not an element with the same tag name as the token, then this is a parse error.
                                if (!state.IsCurrentOneOfTag(entity.Data))
                                    state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                                else
                                {
                                    //Pop elements from this stack until an element with the same tag name as the token has been popped from the stack.
                                    state.CloseInStack(entity.Data);
                                }

                                //Clear the list of active formatting elements up to the last marker.
                                state.ActiveFormattingElements.ClearToMarker();

                                //Switch the insertion mode to "in row". (The current node will be a tr element at this point.)
                                state.Switch(InRow);
                            }
                        }
                        // An end tag whose tag name is one of: "body", "caption", "col", "colgroup", "html"
                        else if (entity.IsOneOfTag("body", "caption", "col", "colgroup", "html"))
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // An end tag whose tag name is one of: "table", "tbody", "tfoot", "thead", "tr"
                        else if (entity.IsOneOfTag("table", "tbody", "tfoot", "thead", "tr"))
                        {
                            //If the stack of open elements does not have an element in table scope with the same tag name as that of the token (which can only happen for "tbody", "tfoot" and "thead", or, in the fragment case), then this is a parse error and the token must be ignored.
                            if (!state.IsInTableScopeStack(entity.Data))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            else
                            {
                                //Otherwise, close the cell (see below) and reprocess the current token.
                                if (!state.CloseInStack("td"))
                                    state.CloseInStack("th");
                            }
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        // Process the token using the rules for the "in body" insertion mode.
                        _InBody(entity, state);

                        break;
                    }
            }
        }

        private static void _InSelect(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.Data:
                    {
                        // Insert the token's character into the current node.
                        state.AppendDataToCurrent(entity);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the current node with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        // A start tag whose tag name is "option"
                        else if (entity.IsTag("option"))
                        {
                            // If the current node is an option  element, act as if an end tag with the tag name "option" had been seen.
                            if (state.IsCurrentOneOfTag("option"))
                                state.Pop();

                            // Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        // A start tag whose tag name is "optgroup"
                        else if (entity.IsTag("optgroup"))
                        {
                            //If the current node is an option element, act as if an end tag with the tag name "option" had been seen.
                            if (state.IsCurrentOneOfTag("option"))
                                state.Pop();

                            //If the current node is an optgroup element, act as if an end tag with the tag name "optgroup" had been seen.
                            if (state.IsCurrentOneOfTag("optgroup"))
                                state.Pop();

                            //Insert an HTML element for the token.
                            state.CreatePushElement(entity, StdNamespaces.HTML);
                        }
                        // A start tag whose tag name is "select"
                        else if (entity.IsTag("select"))
                        {
                            // Parse error. Act as if the token had been an end tag with the tag name "select" instead.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            // TODO : Act as if the token had been an end tag with the tag name "select" instead.
                        }
                        // A start tag whose tag name is one of: "input", "textarea"
                        else if (entity.IsOneOfTag("input", "textarea"))
                        {
                            // Parse error. Act as if an end tag with the tag name "select" had been seen, and reprocess the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            // TODO : Act as if an end tag with the tag name "select" had been seen, and reprocess the token.
                        }
                        // A start tag token whose tag name is "script"
                        else if (entity.IsTag("script"))
                        {
                            // Process the token using the rules for the "in head" insertion mode.
                            _InHead(entity, state);
                        }
                        // Anything else
                        else
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "optgroup"
                        if (entity.IsTag("optgroup"))
                        {
                            //First, if the current node is an option element, and the node immediately before it in the stack of open elements is an optgroup element, 
                            //then act as if an end tag with the tag name "option" had been seen.
                            if (state.IsCurrentOneOfTag("option"))
                                state.Pop();

                            //If the current node is an optgroup element, then pop that node from the stack of open elements. 
                            //Otherwise, this is a parse error; ignore the token.
                            if (state.IsCurrentOneOfTag("optgroup"))
                            {
                                state.Pop();
                            }
                            else
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                        }
                        // An end tag whose tag name is "option"
                        else if (entity.IsTag("option"))
                        {
                            // If the current node is an option  element, then pop that node from the stack of open elements. Otherwise, this is a parse error; ignore the token.
                            if (state.IsCurrentOneOfTag("option"))
                                state.Pop();
                            else
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }
                        // An end tag whose tag name is "select"
                        else if (entity.IsTag("select"))
                        {
                            //If the stack of open elements does not have an element in table scope with the same tag name as the token, this is a parse error. Ignore the token. (fragment case)
                            if (!state.IsInTableScopeStack("select"))
                            {
                                state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                            }
                            //Otherwise:
                            else
                            {
                                //Pop elements from the stack of open elements until a select element has been popped from the stack.
                                state.CloseInStack("select");

                                //Reset the insertion mode appropriately.
                                // TODO : ?
                            }
                        }
                        // Anything else
                        else
                        {
                            // Parse error. Ignore the token.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);
                        }

                        break;
                    }
            }
        }

        private static void _InSelectInTable(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is one of: "caption", "table", "tbody", "tfoot", "thead", "tr", "td", "th"
                        if (entity.IsOneOfTag("caption", "table", "tbody", "tfoot", "thead", "tr", "td", "th"))
                        {
                            //Parse error. Act as if an end tag with the tag name "select" had been seen, and reprocess the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);

                            state.CloseInStack("select");

                            state.Repeat();
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in select" insertion mode.
                            _InSelect(entity, state);
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is one of: "caption", "table", "tbody", "tfoot", "thead", "tr", "td", "th"
                        if (entity.IsOneOfTag("caption", "table", "tbody", "tfoot", "thead", "tr", "td", "th"))
                        {
                            // Parse error.
                            state.SetError(EntityErrorCode.UnexpectedEndTag, entity);

                            // If the stack of open elements has an element in table scope with the same tag name as that of the token, 
                            // then act as if an end tag with the tag name "select" had been seen, and reprocess the token. Otherwise, ignore the token.

                            if (state.IsInTableScopeStack(entity.Data))
                            {
                                state.CloseInStack("select");
                                state.Repeat();
                            }
                        }
                        // Anything else
                        else
                        {
                            // Process the token using the rules for the "in select" insertion mode.
                            _InSelect(entity, state);
                        }

                        break;
                    }
                // Anything else
                default:
                    {
                        // Process the token using the rules for the "in select" insertion mode.
                        _InSelect(entity, state);

                        break;
                    }
            }
        }

        private static void _AfterBody(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.WhiteSpace:
                    {
                        // Process the token using the rules for the "in body" insertion mode.
                        _InBody(entity, state);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the first element in the stack of open elements (the html  element), 
                        // with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                case EntityType.DOCType:
                    {
                        // Parse error. Ignore the token.
                        state.SetError(EntityErrorCode.DocTypeUnexpected, entity);
                        break;
                    }
                case EntityType.OpenElement:
                    {
                        // A start tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // Process the token using the rules for the "in body" insertion mode.
                            _InBody(entity, state);
                        }
                        // Anything else
                        else
                        {
                            // Parse error. Switch the insertion mode to "in body" and reprocess the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            state.Switch(InBody);
                            state.Repeat();
                        }

                        break;
                    }
                case EntityType.CloseElement:
                    {
                        // An end tag whose tag name is "html"
                        if (entity.IsTag("html"))
                        {
                            // If the parser was originally created as part of the HTML fragment parsing algorithm, this is a parse error; ignore the token. (fragment case)
                            // Otherwise, switch the insertion mode to "after after body".
                            state.Switch(AfterAfterBody);
                        }
                        // Anything else
                        else
                        {
                            // Parse error. Switch the insertion mode to "in body" and reprocess the token.
                            state.SetError(EntityErrorCode.UnexpectedStartTag, entity);
                            state.Switch(InBody);
                            state.Repeat();
                        }

                        break;
                    }
            }
        }

        private static void _AfterAfterBody(Entity entity, TreeConstructionState state)
        {
            switch (entity.Type)
            {
                case EntityType.DOCType:
                    {
                        // Process the token using the rules for the "in body" insertion mode.
                        _InBody(entity, state);
                        break;
                    }
                case EntityType.WhiteSpace:
                    {
                        // Process the token using the rules for the "in body" insertion mode.
                        _InBody(entity, state);
                        break;
                    }
                case EntityType.Comment:
                    {
                        // Append a Comment node to the Document  object with the data attribute set to the data given in the comment token.
                        state.AppendCommentToCurrent(entity);
                        break;
                    }
                // Anything else
                default:
                    {
                        // Parse error. Switch the insertion mode  to "in body" and reprocess the token.
                        state.SetError(EntityErrorCode.UnexpectedTag, entity);
                        _InBody(entity, state);
                        break;
                    }
            }
        }
    }
}
