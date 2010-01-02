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

namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/html5/dom.html#htmlelement
    public class HTMLElement : Element
    {
        public HTMLElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        // Fix : This is temporary because of too much inherited abstract classes
        protected HTMLElement()
            : base(null, null)
        {

        }

        public string Id
        {
            get
            {
                if (this.Attributes.Id != null)
                {
                    return this.Attributes.Id.Value;
                }

                return null;
            }
            set
            {
                if (this.Attributes.Id != null)
                {
                    this.Attributes.Id.Value = value;
                }
                else
                {
                    this.SetAttribute(NonLocalizedStrings.Id, value);
                }
            }
        }

        public string Title
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Title);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Title, value);
            }
        }

        public string Lang
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Lang);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Lang, value);
            }
        }

        public string Dir
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Dir);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Dir, value);
            }
        }

        public string ClassName
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Class);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Class, value);
            }
        }

        public int TabIndex
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

        public string AccessKey
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

        public void Blur()
        {
            throw new NotImplementedException();
        }

        public void Focus()
        {
            throw new NotImplementedException();
        }

        public string InnerHTML
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

        public string OuterHTML
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

        public void insertAdjacentHTML(string position, string text)
        {
            throw new NotImplementedException();
        }

        public TokenList ClassList
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public StringMap Dataset
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SettableTokenList Item
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public SettableTokenList ItemProp
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        //public HTMLPropertyCollection Properties
        //{
        //    get
        //    {
                
        //    }
        //}

        public string Content
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

        public string Subject
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

        public bool Hidden
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

        public void Click()
        {
            throw new NotImplementedException();
        }

        // more..

    }
}
