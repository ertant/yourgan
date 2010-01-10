using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormControlValidation : HTMLFormControl, IValidatedControl
    {
        public HTMLFormControlValidation(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public abstract bool WillValidate
        {
            get;
        }

        public abstract ValidityState Validity
        {
            get;
        }

        public abstract string ValidationMessage
        {
            get;
        }

        public abstract bool CheckValidity();

        public abstract void SetCustomValidity(string error);
    }
}
