using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.CSS
{
    public class CSSStyleDeclaration
    {
        public string CSSText
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

        public string GetPropertyValue(string property)
        {
            throw new NotImplementedException();
        }

        public string GetPropertyPriority(string property)
        {
            throw new NotImplementedException();
        }

        public string RemoveProperty(string property)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string property,string value)
        {
            throw new NotImplementedException();
        }

        public void SetProperty(string property,string value,string priority)
        {
            throw new NotImplementedException();
        }

        public ulong Length
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string this[ulong index]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CSSRule ParentRule
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        // TODO : CSS Properties
    }
}
