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
    // http://www.w3.org/TR/html5/semantics.html#the-html-element-0
    public class HTMLHtmlElement : HTMLElement
    {
        public HTMLHtmlElement(QualifiedName qname, Document document)
            : base(qname, document)
        {
        }

        public HTMLElement Head
        {
            get
            {
                HTMLElement head = this.FindFirstChild<HTMLElement>(HTMLTagNames.Head);

                if (head == null)
                {
                    head = this.OwnerDocument.CreateElement<HTMLElement>(HTMLTagNames.Head);

                    this.AppendChild(head);
                }

                return head;
            }
        }

        public string DocumentTitle
        {
            get
            {
                if (this.Head != null)
                {
                    HTMLTitleElement title = this.Head.FindFirstChild<HTMLTitleElement>(HTMLTagNames.Title);

                    if (title != null)
                    {
                        return title.Text;
                    }
                }

                return null;
            }
            set
            {
                if (this.Head != null)
                {
                    HTMLTitleElement titleElement = this.Head.FindFirstChild<HTMLTitleElement>(HTMLTagNames.Title);

                    if (titleElement != null)
                    {
                        titleElement = this.OwnerDocument.CreateElement<HTMLTitleElement>(HTMLTagNames.Title);

                        this.Head.AppendChild(titleElement);

                        titleElement.Text = value;
                    }
                }
            }
        }

        public HTMLElement Body
        {
            get
            {
                HTMLElement body = this.FindFirstChild<HTMLElement>(HTMLTagNames.Body);

                if (body == null)
                {
                    body = this.FindFirstChild<HTMLElement>(HTMLTagNames.FrameSet);
                }

                return body;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");

                if (!HTMLTagNames.IsSame(value.LocalName, HTMLTagNames.Body) &&
                    !HTMLTagNames.IsSame(value.LocalName, HTMLTagNames.FrameSet))
                    throw new DOMException(DOMError.HierarchyRequest);

                HTMLElement body = this.FindFirstChild<HTMLElement>(HTMLTagNames.Body);

                if (value != body)
                {
                    if (body != null)
                    {
                        this.ReplaceChild(value, body);
                    }
                    else
                    {
                        this.AppendChild(value);
                    }
                }
            }
        }
    }
}
