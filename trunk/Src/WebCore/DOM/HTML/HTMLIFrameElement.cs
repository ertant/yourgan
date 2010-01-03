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
    public class HTMLIFrameElement : HTMLElement
    {
        public HTMLIFrameElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

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

        public string Name
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Name);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Name, value);
            }
        }

        public string Sandbox
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Sandbox);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Sandbox, value);
            }
        }

        public bool Seamless
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Seamless);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Seamless, value);
            }
        }

        public string Width
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Width);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Width, value);
            }
        }

        public string Height
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Height);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Height, value);
            }
        }

        public Document ContentDocument
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // TODO : Fix here
        //public abstract Window ContentWindow
        //{
        //    get;
        //}

        #endregion
    }
}
