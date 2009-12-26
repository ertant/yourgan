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

        public HTMLTitleElement GetTitleElement()
        {
            Node child = this.FirstChild;

            while (child != null)
            {
                if (HTMLTagNames.IsSame(child.LocalName, HTMLTagNames.Title))
                {
                    return child as HTMLTitleElement;
                }

                child = child.NextSibling;
            }

            return null;
        }

        public void SetTitle(string title)
        {
            HTMLTitleElement titleElement = GetTitleElement();

            if (titleElement == null)
            {
                titleElement = this.OwnerDocument.CreateElement(HTMLTagNames.Title) as HTMLTitleElement;

                this.AppendChild(titleElement);

                titleElement.Text = title;
            }
        }
    }
}
