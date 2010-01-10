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

        #region DOM

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
                return this.ReflectAttribute(NonLocalizedStrings.Title);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Title, value);
            }
        }

        public string Lang
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Lang);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Lang, value);
            }
        }

        public string Dir
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Dir);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Dir, value);
            }
        }

        public string ClassName
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Class);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Class, value);
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

        public virtual string Content
        {
            get
            {
                // TODO : Behaivor changes on some elements like "meta","a","object".. 
                // Verify later.
                return this.TextContent;
            }
            set
            {
                this.TextContent = value;
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
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Hidden);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Hidden, value);
            }
        }

        public void Click()
        {
            throw new NotImplementedException();
        }

        // more..

        #endregion

        protected string ReflectAttribute(string name)
        {
            return this.GetAttribute(name);
        }

        protected void ReflectAttribute(string name, string value)
        {
            this.SetAttribute(name, value);
        }

        protected ulong ReflectAttributeULong(string name)
        {
            return ulong.Parse(this.GetAttribute(name), System.Globalization.CultureInfo.InvariantCulture);
        }

        protected void ReflectAttributeULong(string name, ulong value)
        {
            this.SetAttribute(name, value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        protected long ReflectAttributeLong(string name)
        {
            return long.Parse(this.GetAttribute(name), System.Globalization.CultureInfo.InvariantCulture);
        }

        protected void ReflectAttributeLong(string name, long value)
        {
            this.SetAttribute(name, value.ToString(System.Globalization.CultureInfo.InvariantCulture));
        }

        protected void ReflectAttributeBoolean(string name, bool value)
        {
            if (value)
                this.SetAttribute(name, "");
            else
                this.Attributes.RemoveNamedItem(name);
        }

        protected bool ReflectAttributeBoolean(string name)
        {
            Node node = this.GetAttributeNode(name);

            if (node != null)
                return true;

            return false;
        }

        protected T FindFirstChild<T>() where T : class
        {
            Node child = this.FirstChild;

            while (child != null)
            {
                T expected = child as T;

                if (expected != null)
                    return expected;

                child = child.NextSibling;
            }

            return null;
        }

        protected T FindFirstChild<T>(string tagName) where T : class
        {
            Node child = this.FirstChild;

            while (child != null)
            {
                if (HTMLTagNames.IsSame(child.LocalName, tagName))
                    return child as T;

                child = child.NextSibling;
            }

            return null;
        }
    }
}
