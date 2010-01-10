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
    // http://www.w3.org/TR/html5/forms.html#the-input-element
    public abstract class HTMLInputElement : HTMLFormControlValidation
    {
        public HTMLInputElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public string Accept
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Accept);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Accept, value);
            }
        }

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

        public bool DefaultChecked
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Checked);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Checked, value);
            }
        }

        public abstract bool Checked
        {
            get;
            set;
        }

        // TODO : Files

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

        public abstract bool Indeterminate
        {
            get;
            set;
        }

        public abstract HTMLElement List
        {
            get;
        }

        public string Max
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Max);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Max, value);
            }
        }

        public ulong MaxLength
        {
            get
            {
                return this.ReflectAttributeULong(NonLocalizedStrings.Alt);
            }
            set
            {
                this.ReflectAttributeULong(NonLocalizedStrings.Alt, value);
            }
        }

        public string Min
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Min);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Min, value);
            }
        }

        public bool Multiple
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Multiple);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Multiple, value);
            }
        }

        public string Pattern
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Pattern);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Pattern, value);
            }
        }

        public string PlaceHolder
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.PlaceHolder);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.PlaceHolder, value);
            }
        }

        public bool Readonly
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Readonly);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Readonly, value);
            }
        }

        public bool Required
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.Required);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.Required, value);
            }
        }

        public ulong Size
        {
            get
            {
                return this.ReflectAttributeULong(NonLocalizedStrings.Size);
            }
            set
            {
                this.ReflectAttributeULong(NonLocalizedStrings.Size, value);
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

        public string Step
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Step);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Step, value);
            }
        }

        public string DefaultValue
        {
            get
            {
                return this.ReflectAttribute(NonLocalizedStrings.Value);
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.Value, value);
            }
        }

        public DateTime ValueAsDate
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

        public float ValueAsNumber
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

        public HTMLOptionElement SelectedOption
        {
            get
            {
                throw new NotImplementedException();
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

        public void StepUp(int n)
        {
            throw new NotImplementedException();
        }

        public void StepDown(int n)
        {
            throw new NotImplementedException();
        }

        public NodeList Labels
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Select()
        {
            throw new NotImplementedException();
        }

        public int SelectionStart
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

        public int SelectionEnd
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

        public void SetSelectionRange(int start, int end)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
