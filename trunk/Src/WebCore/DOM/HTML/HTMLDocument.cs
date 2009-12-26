using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        #region DOM

        public string Title
        {
            get
            {
                HTMLTitleElement title = this.Head.GetTitleElement();

                if (title != null)
                {
                    return title.Text;
                }

                return null;
            }
            set
            {
                this.Head.SetTitle(value);
            }
        }

        public abstract string Referrer
        {
            get;
        }

        public abstract string Domain
        {
            get;
        }

        public abstract string URL
        {
            get;
        }

        private HTMLBodyElement body;

        public HTMLBodyElement Body
        {
            get
            {
                if (body == null)
                {
                    body = this.CreateElementNS(this.NamespaceURI, HTMLTagNames.Body) as HTMLBodyElement;

                    this.AppendChild(body);
                }

                return body;

                // TODO : Frameset
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                this.RemoveChild(body);
                body = value;
                this.AppendChild(value);
            }
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

        public string Cookie
        {
            get;
            set;
        }

        public abstract void Open();

        public abstract void Close();

        public abstract void Write(string text);

        public abstract void WriteLn(string text);

        public abstract NodeList GetElementsByName(string elementName);

        #endregion

        public override string DefaultNamespaceURI
        {
            get
            {
                return StdNamespaces.HTML;
            }
        }

        private HTMLHeadElement head;

        public HTMLHeadElement Head
        {
            get
            {
                if (head == null)
                {
                    head = this.CreateElement(HTMLTagNames.Head) as HTMLHeadElement;

                    this.AppendChild(head);
                }

                return head;
            }
        }
    }
}
