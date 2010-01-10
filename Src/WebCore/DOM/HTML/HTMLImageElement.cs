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
    // http://www.w3.org/TR/html5/text-level-semantics.html#the-img-element
    public class HTMLImageElement : HTMLElement
    {
        public HTMLImageElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public string Alt
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Alt);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Alt, value);
            }
        }

        public string Src
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Src);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Src, value);
            }
        }

        public string UseMap
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.UseMap);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.UseMap, value);
            }
        }

        public bool IsMap
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.IsMap);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.IsMap, value);
            }
        }

        public ulong Width
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

        public ulong Height
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

        public bool Complete
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
