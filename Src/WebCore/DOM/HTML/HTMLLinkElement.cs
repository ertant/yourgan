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
namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/html5/semantics.html#the-link-element
    public abstract class HTMLLinkElement : HTMLElement // TODO : , CSS.LinkStyle
    {
        public HTMLLinkElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public bool Disabled
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Disabled);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Disabled, value);
            }
        }

        public string HRef
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.HRef);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.HRef, value);
            }
        }

        public string Rel
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Rel);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Rel, value);
            }
        }

        public abstract TokenList RelList
        {
            get;
        }

        public string Media
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Media);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Media, value);
            }
        }

        public string HRefLang
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.HRefLang);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.HRefLang, value);
            }
        }

        public string Type
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Type);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Type, value);
            }
        }

        public string Sizes
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Sizes);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Sizes, value);
            }
        }

        #endregion
    }
}
