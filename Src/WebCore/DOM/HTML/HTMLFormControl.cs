using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormControl : HTMLElement
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

        public abstract HTMLFormElement Form
        {
            get;
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
