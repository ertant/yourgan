using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.CSS
{
    public class CSSRule
    {
        private CSSRuleType type;

        public CSSRuleType Type
        {
            get
            {
                return type;
            }
        }

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

        public CSSRule ParentRule
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CSSStyleSheet ParentStyleSheet
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
