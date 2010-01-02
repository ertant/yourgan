using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public class HTMLHeadElement : HTMLElement
    {
        public HTMLHeadElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region  DOM

        public string Profile
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

        #endregion


    }
}
