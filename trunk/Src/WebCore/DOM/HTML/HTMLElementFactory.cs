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
using System.Collections.Generic;

namespace Yourgan.Core.DOM.HTML
{
    public class HTMLElementFactory : ElementFactory
    {
        private delegate HTMLElement ConstructionHandler(QualifiedName qname, Document document);

        private Dictionary<string, ConstructionHandler> Constructors = new Dictionary<string, ConstructionHandler>(StringComparer.OrdinalIgnoreCase);

        public HTMLElementFactory()
        {
            this.Constructors[HTMLTagNames.Html] = Html;
            this.Constructors[HTMLTagNames.Head] = Head;
            this.Constructors[HTMLTagNames.Body] = Body;
            this.Constructors[HTMLTagNames.Br] = Br;
            this.Constructors[HTMLTagNames.Hr] = Hr;
            this.Constructors[HTMLTagNames.Div] = Div;
            this.Constructors[HTMLTagNames.Form] = Form;
            this.Constructors[HTMLTagNames.H1] = Heading;
            this.Constructors[HTMLTagNames.H2] = Heading;
            this.Constructors[HTMLTagNames.H3] = Heading;
            this.Constructors[HTMLTagNames.H4] = Heading;
            this.Constructors[HTMLTagNames.H5] = Heading;
            this.Constructors[HTMLTagNames.H6] = Heading;
            this.Constructors[HTMLTagNames.IFrame] = IFrame;
            this.Constructors[HTMLTagNames.Img] = Image;
            this.Constructors[HTMLTagNames.P] = Paragraph;
            this.Constructors[HTMLTagNames.Option] = Option;
            this.Constructors[HTMLTagNames.Meta] = Meta;
            this.Constructors[HTMLTagNames.Map] = Map;
            this.Constructors[HTMLTagNames.Li] = Li;
            this.Constructors[HTMLTagNames.Legend] = Legend;
            this.Constructors[HTMLTagNames.Caption] = Caption;
        }

        public override T Create<T>(QualifiedName qname, Document document)
        {
            ConstructionHandler handler;

            if (Constructors.TryGetValue(qname.LocalName, out handler))
            {
                return handler(qname, document) as T;
            }

            return base.Create<T>(qname, document);
        }

        private static HTMLElement Html(QualifiedName qname, Document document)
        {
            HTMLHtmlElement element = new HTMLHtmlElement(qname, document);

            return element;
        }

        private static HTMLElement Head(QualifiedName qname, Document document)
        {
            HTMLElement element = new HTMLElement(qname, document);

            return element;
        }

        private static HTMLElement Body(QualifiedName qname, Document document)
        {
            HTMLBodyElement element = new HTMLBodyElement(qname, document);

            return element;
        }

        private static HTMLElement Br(QualifiedName qname, Document document)
        {
            HTMLBRElement element = new HTMLBRElement(qname, document);

            return element;
        }

        private static HTMLElement Hr(QualifiedName qname, Document document)
        {
            HTMLHRElement element = new HTMLHRElement(qname, document);

            return element;
        }

        private static HTMLElement Div(QualifiedName qname, Document document)
        {
            HTMLDivElement element = new HTMLDivElement(qname, document);

            return element;
        }

        private static HTMLElement Form(QualifiedName qname, Document document)
        {
            HTMLFormElement element = new HTMLFormElement(qname, document);

            return element;
        }

        private static HTMLElement Heading(QualifiedName qname, Document document)
        {
            HTMLHeadingElement element = new HTMLHeadingElement(qname, document);

            return element;
        }

        private static HTMLElement IFrame(QualifiedName qname, Document document)
        {
            HTMLIFrameElement element = new HTMLIFrameElement(qname, document);

            return element;
        }

        private static HTMLElement Image(QualifiedName qname, Document document)
        {
            HTMLImageElement element = new HTMLImageElement(qname, document);

            return element;
        }

        private static HTMLElement Paragraph(QualifiedName qname, Document document)
        {
            HTMLParagraphElement element = new HTMLParagraphElement(qname, document);

            return element;
        }

        private static HTMLElement Option(QualifiedName qname, Document document)
        {
            HTMLOptionElement element = new HTMLOptionElement(qname, document);

            return element;
        }

        private static HTMLElement Meta(QualifiedName qname, Document document)
        {
            HTMLMetaElement element = new HTMLMetaElement(qname, document);

            return element;
        }

        private static HTMLElement Map(QualifiedName qname, Document document)
        {
            HTMLMapElement element = new HTMLMapElement(qname, document);

            return element;
        }

        private static HTMLElement Li(QualifiedName qname, Document document)
        {
            HTMLLIElement element = new HTMLLIElement(qname, document);

            return element;
        }

        private static HTMLElement Legend(QualifiedName qname, Document document)
        {
            HTMLLegendElement element = new HTMLLegendElement(qname, document);

            return element;
        }

        private static HTMLElement Caption(QualifiedName qname, Document document)
        {
            HTMLTableCaptionElement element = new HTMLTableCaptionElement(qname, document);

            return element;
        }
    }
}
