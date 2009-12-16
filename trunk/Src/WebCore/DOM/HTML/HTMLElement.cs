using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLElement : Element
    {
        public HTMLElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        // Fix : This is temporary because of too much inherited abstract classes
        protected HTMLElement()
            : base(null, null)
        {

        }

        public string Id
        {
            get
            {
                if (this.Attributes.Id != null)
                {
                    return this.Attributes.Id.Value;
                }

                return null;
            }
            set
            {
                if (this.Attributes.Id != null)
                {
                    this.Attributes.Id.Value = value;
                }
                else
                {
                    this.SetAttribute(NonLocalizedStrings.Id, value);
                }
            }
        }

        public string Title
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Title);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Title, value);
            }
        }

        public string Lang
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Lang);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Lang, value);
            }
        }

        public string Dir
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Dir);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Dir, value);
            }
        }

        public string ClassName
        {
            get
            {
                return this.GetAttribute(NonLocalizedStrings.Class);
            }
            set
            {
                this.SetAttribute(NonLocalizedStrings.Class, value);
            }
        }
    }
}
