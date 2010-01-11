using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.CSS
{
    public class CSSStyleSheet : StyleSheet
    {
        private CSSRule ownerRule;

        public CSSRule OwnerRule
        {
            get
            {
                return ownerRule;
            }
        }

        public CSSRuleList CSSRules
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong InsertRule(string rule, ulong index)
        {
            throw new NotImplementedException();
        }

        public void DeleteRule(ulong index)
        {
            throw new NotImplementedException();
        }
    }
}
