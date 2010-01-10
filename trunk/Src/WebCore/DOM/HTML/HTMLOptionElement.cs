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
    // http://www.w3.org/TR/html5/forms.html#the-option-element
    public class HTMLOptionElement : HTMLFormBoundElement
    {
        public HTMLOptionElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

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

        public string Label
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Label);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Label, value);
            }
        }

        public bool DefaultSelected
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Selected);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Selected, value);
            }
        }

        public bool Selected
        {
            get
            {
                if (this.Disabled)
                    return false;

                return this.ReflectAttributeBoolean(NonLocalizedStrings.Selected);
            }
            set
            {
                if (this.Disabled)
                    this.ReflectAttributeBoolean(NonLocalizedStrings.Selected, false);

                this.ReflectAttributeBoolean(NonLocalizedStrings.Selected, value);
            }
        }

        public string Value
        {
            get
            {
                string v = this.ReflectAttribute(NonLocalizedStrings.Value);

                if (string.IsNullOrEmpty(v))
                {
                    return this.TextContent;
                }

                return v;
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Value, value);
            }
        }

        public string Text
        {
            get
            {
                return this.TextContent;
            }
            set
            {
                this.TextContent = value;
            }
        }

        public long Index
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
