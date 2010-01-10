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
    // http://www.w3.org/TR/html5/forms.html#the-optgroup-element
    public abstract class HTMLOptGroupElement : HTMLElement
    {
        public HTMLOptGroupElement(QualifiedName qname, Document document)
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
    }
}
