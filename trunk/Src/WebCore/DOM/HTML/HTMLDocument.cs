// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System;
using Yourgan.Core.Parser;

namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/2003/REC-DOM-Level-2-HTML-20030109/html.html#ID-26809268
    public abstract class HTMLDocument : Document
    {
        public HTMLDocument()
        {
            this.RegisterFactory(StdNamespaces.HTML, new HTMLElementFactory());
        }

        protected internal T GetElementByTagName<T>(Node parent, string tagName) where T : Element
        {
            Node child = parent.FirstChild;

            while (child != null)
            {
                if (HTMLTagNames.IsSame(child.LocalName, tagName))
                {
                    return child as T;
                }

                child = child.NextSibling;
            }

            return null;
        }

        #region DOM

        public string Title
        {
            get
            {
                HTMLTitleElement title = GetElementByTagName<HTMLTitleElement>(this.Head, HTMLTagNames.Title);

                if (title != null)
                {
                    return title.Text;
                }

                return null;
            }
            set
            {
                HTMLTitleElement titleElement = GetElementByTagName<HTMLTitleElement>(this.Head, HTMLTagNames.Title);

                if (titleElement != null)
                {
                    titleElement = this.OwnerDocument.CreateElement<HTMLTitleElement>(HTMLTagNames.Title);

                    this.Head.AppendChild(titleElement);

                    titleElement.Text = value;
                }
            }
        }

        public abstract Location Location
        {
            get;
        }

        public abstract string URL
        {
            get;
        }

        public abstract string Domain
        {
            get;
            set;
        }

        public abstract string Referrer
        {
            get;
        }

        public string Cookie
        {
            get;
            set;
        }

        public abstract string LastModified
        {
            get;
        }

        public abstract string CompactMode
        {
            get;
        }

        public string Charset
        {
            get;
            set;
        }

        public abstract string CharacterSet
        {
            get;
        }

        public abstract string DefaultCharset
        {
            get;
        }

        public abstract string ReadyState
        {
            get;
        }

        public HTMLElement Body
        {
            get
            {
                HTMLElement body = this.GetElementByTagName<HTMLElement>(this, HTMLTagNames.Body);

                if (body == null)
                {
                    body = this.GetElementByTagName<HTMLElement>(this, HTMLTagNames.FrameSet);
                }

                return body;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (!HTMLTagNames.IsSame(value.LocalName, HTMLTagNames.Body) &&
                    !HTMLTagNames.IsSame(value.LocalName, HTMLTagNames.FrameSet))
                    throw new DOMException(DOMError.HierarchyRequest);

                HTMLElement body = this.GetElementByTagName<HTMLElement>(this, HTMLTagNames.Body);

                if (value != body)
                {
                    if (body != null)
                    {
                        this.ReplaceChild(value, body);
                    }
                    else
                    {
                        this.AppendChild(value);
                    }
                }
            }
        }

        public abstract string InnerHtml
        {
            get;
        }

        public abstract HTMLCollection Images
        {
            get;
        }

        public abstract HTMLCollection Applets
        {
            get;
        }

        public abstract HTMLCollection Links
        {
            get;
        }

        public abstract HTMLCollection Forms
        {
            get;
        }

        public abstract HTMLCollection Anchors
        {
            get;
        }

        public abstract HTMLCollection Scripts
        {
            get;
        }

        public abstract HTMLDocument Open();

        public abstract void Close();

        public abstract void Write(string text);

        public abstract void WriteLn(string text);

        public abstract NodeList GetElementsByName(string elementName);

        public abstract NodeList GetElementsByClassName(string classNames);

        #endregion

        public override string DefaultNamespaceURI
        {
            get
            {
                return StdNamespaces.HTML;
            }
        }

        private HTMLElement head;

        public HTMLElement Head
        {
            get
            {
                if (head == null)
                {
                    head = this.CreateElement<HTMLElement>(HTMLTagNames.Head);

                    this.AppendChild(head);
                }

                return head;
            }
        }
    }
}
