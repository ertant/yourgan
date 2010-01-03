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
    // http://www.w3.org/TR/html5/forms.html#the-form-element
    public class HTMLFormElement : HTMLElement
    {
        public HTMLFormElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public string AcceptCharset
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.AcceptCharset);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.AcceptCharset, value);
            }
        }

        public string Action
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Action);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Action, value);
            }
        }

        public bool AutoComplete
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.AutoComplete);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.AutoComplete, value);
            }
        }

        public string EncType
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.EncType);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.EncType, value);
            }
        }

        public string Method
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Method);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Method, value);
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

        public bool NoValidate
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.NoValidate);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.NoValidate, value);
            }
        }

        public string Target
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Target);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Target, value);
            }
        }

        public HTMLFormControlsCollection Elements
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong Length
        {
            get
            {
                return this.Elements.Length;
            }
        }

        public HTMLElement this[int index]
        {
            get
            {
                return this.Elements[index];
            }
        }

        public HTMLElement this[string name]
        {
            get
            {
                return this.Elements[name];
            }
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void CheckValidity()
        {
            throw new NotImplementedException();
        }

        public void DispatchFormInput()
        {
            throw new NotImplementedException();
        }

        public void DispatchFormChange()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
