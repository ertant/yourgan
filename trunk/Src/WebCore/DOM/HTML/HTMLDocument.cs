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
    // http://www.w3.org/TR/html5/dom.html#htmldocument
    public class HTMLDocument : Document
    {
        public HTMLDocument()
        {
            this.RegisterFactory(StdNamespaces.HTML, new HTMLElementFactory());
        }

        #region DOM

        #region resource metadata management

        public Location Location
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string URL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Domain
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Referrer
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Cookie
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string LastModified
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string CompactMode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Charset
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string CharacterSet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string DefaultCharset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string ReadyState
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region DOM tree accessors

        public string Title
        {
            get
            {
                return this.HTML.DocumentTitle;
            }
            set
            {
                this.HTML.DocumentTitle = value;
            }
        }

        public string Dir
        {
            get
            {
                return this.HTML.Dir;
            }
            set
            {
                this.HTML.Dir = value;
            }
        }

        public HTMLElement Body
        {
            get
            {
                return this.HTML.Body;
            }
            set
            {
                this.HTML.Body = value;
            }
        }

        public HTMLCollection Images
        {
            get
            {
                return new HTMLFilteredCollection(this.Body, "//img");
            }
        }

        public HTMLCollection Embeds
        {
            get
            {
                return new HTMLFilteredCollection(this.Body, "//embed");
            }
        }

        public HTMLCollection Plugins
        {
            get
            {
                return this.Embeds;
            }
        }

        public HTMLCollection Links
        {
            get
            {
                return new HTMLFilteredCollection(this.Body, "//a[@href!=''] | //area[@href!='']");
            }
        }

        public HTMLCollection Forms
        {
            get
            {
                return new HTMLFilteredCollection(this.Body, "//form");
            }
        }

        public HTMLCollection Scripts
        {
            get
            {
                return new HTMLFilteredCollection(this.Body, "//script");
            }
        }

        public NodeList GetElementsByName(string elementName)
        {
            throw new NotImplementedException();
        }

        public NodeList GetElementsByClassName(string classNames)
        {
            throw new NotImplementedException();
        }

        public NodeList GetItems(string typeNames)
        {
            throw new NotImplementedException();
        }

        public object this[string name]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region dynamic markup insertion

        public string InnerHtml
        {
            get
            {
                return this.HTML.InnerHTML;
            }
            set
            {
                this.HTML.InnerHTML = value;
            }
        }

        public HTMLDocument Open()
        {
            throw new NotImplementedException();
        }

        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Write(string text)
        {
            throw new NotImplementedException();
        }

        public void WriteLn(string text)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region user interaction

        // TODO :

        #endregion

        #endregion

        public override string DefaultNamespaceURI
        {
            get
            {
                return StdNamespaces.HTML;
            }
        }

        public HTMLHtmlElement HTML
        {
            get
            {
                HTMLHtmlElement html = this.DocumentElement as HTMLHtmlElement;

                System.Diagnostics.Debug.Assert(html != null, "HTML is null");

                return html;
            }
        }
    }
}
