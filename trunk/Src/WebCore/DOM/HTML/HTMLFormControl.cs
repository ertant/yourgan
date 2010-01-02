using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormControl : HTMLElement
    {
        public abstract bool AutoFocus
        {
            get;
            set;
        }

        public abstract bool Disabled
        {
            get;
            set;
        }

        public abstract HTMLFormElement Form
        {
            get;
        }

        public abstract string FormAction
        {
            get;
            set;
        }

        public abstract string FormEncType
        {
            get;
            set;
        }

        public abstract string FormMethod
        {
            get;
            set;
        }

        public abstract string FormNoValidate
        {
            get;
            set;
        }

        public abstract string FormTarget
        {
            get;
            set;
        }

        public abstract string Name
        {
            get;
            set;
        }

        public abstract string Type
        {
            get;
            set;
        }

        public abstract string Value
        {
            get;
            set;
        }
    }
}
