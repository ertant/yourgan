using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public interface IValidatedControl
    {
        bool WillValidate
        {
            get;
        }

        ValidityState Validity
        {
            get;
        }

        string ValidationMessage
        {
            get;
        }

        bool CheckValidity();

        void SetCustomValidity(string error);
    }
}
