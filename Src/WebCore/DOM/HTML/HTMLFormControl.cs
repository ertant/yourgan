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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormControl : HTMLFormBoundElement
    {
        protected HTMLFormControl(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public bool AutoFocus
        {
            get
            {
                return this.ReflectAttributeBoolean(NonLocalizedStrings.AutoFocus);
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.AutoFocus, value);
            }
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

        public string FormAction
        {
            get
            {
                string val = this.ReflectFormAttribute(NonLocalizedStrings.FormAction);

                if (val == null)
                {
                    val = this.Form.Action;
                }

                return val;
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.FormAction, value);
            }
        }

        public string FormEncType
        {
            get
            {
                string val = this.ReflectFormAttribute(NonLocalizedStrings.FormEncType);

                if (val == null)
                {
                    val = this.Form.EncType;
                }

                return val;
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.FormEncType, value);
            }
        }

        public string FormMethod
        {
            get
            {
                string val = this.ReflectFormAttribute(NonLocalizedStrings.FormMethod);

                if (val == null)
                {
                    val = this.Form.Method;
                }

                return val;
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.FormMethod, value);
            }
        }

        public bool FormNoValidate
        {
            get
            {
                bool? val = this.ReflectFormAttributeBoolean(NonLocalizedStrings.FormNoValidate);

                if (val == null)
                {
                    return this.Form.NoValidate;
                }

                return val.Value;
            }
            set
            {
                this.ReflectAttributeBoolean(NonLocalizedStrings.FormNoValidate, value);
            }
        }

        public string FormTarget
        {
            get
            {
                string val = this.ReflectFormAttribute(NonLocalizedStrings.FormTarget);

                if (val == null)
                {
                    val = this.Form.Target;
                }

                return val;
            }
            set
            {
                this.ReflectAttribute(NonLocalizedStrings.FormTarget, value);
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

        public virtual string Type
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

        public string Value
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

        #endregion

        protected bool IsSubmitButton()
        {
            return string.Equals(this.Type, NonLocalizedStrings.Submit, StringComparison.OrdinalIgnoreCase);
        }

        protected string ReflectFormAttribute(string attributeName)
        {
            if (this.IsSubmitButton())
            {
                Attr attribute = this.GetAttributeNode(attributeName);

                if (attribute != null)
                {
                    return attribute.Value;
                }
            }

            return null;
        }

        protected bool? ReflectFormAttributeBoolean(string attributeName)
        {
            if (this.IsSubmitButton())
            {
                Attr attribute = this.GetAttributeNode(attributeName);

                if (attribute != null)
                {
                    return true;
                }
            }

            return null;
        }
    }
}
