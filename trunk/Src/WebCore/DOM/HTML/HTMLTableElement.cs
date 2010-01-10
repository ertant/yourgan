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
namespace Yourgan.Core.DOM.HTML
{
    class HTMLTableElement : HTMLElement
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
                    HTMLTableCaptionElement caption = this.Caption;

                    if (caption != null)
                    {
                        this.InsertBefore(value, caption);
                    }
                    else
                    {
                        HTMLTableColElement col = this.FindFirstChild<HTMLTableColElement>(HTMLTagNames.ColGroup);

                        if (col != null)
                        {
                            this.InsertBefore(value, col);
                        }
                        else
                        {
                            this.AppendChild(value);
                        }
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
    }
}
