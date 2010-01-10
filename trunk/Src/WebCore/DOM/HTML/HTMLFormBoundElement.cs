using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLFormBoundElement : HTMLElement
    {
        protected HTMLFormBoundElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        #region DOM

        public HTMLFormElement Form
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion
    }
}
