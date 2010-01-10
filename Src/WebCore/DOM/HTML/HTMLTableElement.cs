// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System;

namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/html5/tabular-data.html#the-table-element
    public class HTMLTableElement : HTMLElement
    {
        public HTMLTableElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public HTMLTableCaptionElement Caption
        {
            get
            {
                return this.FindFirstChild<HTMLTableCaptionElement>();
            }
            set
            {
                HTMLTableCaptionElement existing = this.FindFirstChild<HTMLTableCaptionElement>();

                if (existing != null)
                    this.RemoveChild(existing);

                if (value != null)
                {
                    this.InsertBefore(value, this.FirstChild);
                }
            }
        }

        public HTMLTableCaptionElement CreateCaption()
        {
            HTMLTableCaptionElement caption = this.Caption;

            if (caption == null)
            {
                caption = this.OwnerDocument.CreateElement<HTMLTableCaptionElement>(HTMLTagNames.Caption);

                this.Caption = caption;
            }

            return caption;
        }

        public void DeleteCaption()
        {
            this.Caption = null;
        }

        // ReSharper disable InconsistentNaming
        public HTMLTableSectionElement THead
        // ReSharper restore InconsistentNaming
        {
            get
            {
                return this.FindFirstChild<HTMLTableSectionElement>(HTMLTagNames.THead);
            }
            set
            {
                HTMLTableSectionElement existing = this.FindFirstChild<HTMLTableSectionElement>(HTMLTagNames.THead);

                if (existing != null)
                    this.RemoveChild(existing);

                if (value != null)
                {
                    Node refNode = null;

                    refNode = this.Caption;

                    if (refNode == null)
                    {
                        refNode = this.FindFirstChild<HTMLTableColElement>(HTMLTagNames.ColGroup);
                    }

                    if (refNode != null)
                    {
                        this.InsertBefore(value, refNode);
                    }
                    else
                    {
                        this.AppendChild(value);
                    }
                }
            }
        }

        public HTMLTableSectionElement CreateTHead()
        {
            HTMLTableSectionElement thead = this.THead;

            if (thead == null)
            {
                thead = this.OwnerDocument.CreateElement<HTMLTableSectionElement>(HTMLTagNames.THead);

                this.THead = thead;
            }

            return thead;
        }

        public void DeleteTHead()
        {
            this.THead = null;
        }

        // ReSharper disable InconsistentNaming
        public HTMLTableSectionElement TFoot
        // ReSharper restore InconsistentNaming
        {
            get
            {
                return this.FindFirstChild<HTMLTableSectionElement>(HTMLTagNames.TFoot);
            }
            set
            {
                HTMLTableSectionElement existing = this.FindFirstChild<HTMLTableSectionElement>(HTMLTagNames.TFoot);

                if (existing != null)
                    this.RemoveChild(existing);

                if (value != null)
                {
                    Node refNode = null;

                    refNode = this.Caption;

                    if (refNode == null)
                    {
                        refNode = this.FindFirstChild<HTMLTableColElement>(HTMLTagNames.ColGroup);

                        if (refNode == null)
                        {
                            refNode = this.FindFirstChild<HTMLTableColElement>(HTMLTagNames.THead);
                        }
                    }

                    if (refNode != null)
                    {
                        this.InsertBefore(value, refNode);
                    }
                    else
                    {
                        this.AppendChild(value);
                    }
                }
            }
        }

        public HTMLTableSectionElement CreateTFoot()
        {
            HTMLTableSectionElement foot = this.TFoot;

            if (foot == null)
            {
                foot = this.OwnerDocument.CreateElement<HTMLTableSectionElement>(HTMLTagNames.TFoot);

                this.THead = foot;
            }

            return foot;
        }

        public void DeleteTFoot()
        {
            this.TFoot = null;
        }

        public HTMLCollection TBodies
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HTMLTableSectionElement CreateTBody()
        {
            HTMLTableSectionElement newChild = this.OwnerDocument.CreateElement<HTMLTableSectionElement>(HTMLTagNames.TBody);

            // find last body
            Element lastBody = this.FindLastChild<HTMLTableSectionElement>(HTMLTagNames.TBody);

            // insert after it if found, otherwise just add.
            Node reference = lastBody;

            if ( reference != null )
                reference = reference.NextSibling;

            if ( reference != null )
            {
                this.InsertBefore(newChild, reference);
            }
            else
            {
                this.AppendChild(newChild);
            }

            return newChild;
        }

        public HTMLCollection Rows
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public HTMLElement InsertRow(long index)
        {
            throw new NotImplementedException();
        }

        public void DeleteRow(long index)
        {
            throw new NotImplementedException();
        }
    }
}
