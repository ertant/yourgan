using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.CSS
{
    public class CSSMediaRule : CSSRule
    {
        public MediaList Media
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public CSSRuleList CSSRules
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ulong InsertRule(string rule,ulong index)
        {
            throw new NotImplementedException();
        }

        public void DeleteRule(ulong index)
        {
            throw new NotImplementedException();
        }
    }
}
