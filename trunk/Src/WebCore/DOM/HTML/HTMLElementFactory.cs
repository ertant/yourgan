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
            this.Constructors[HTMLTagNames.Head] = Head;
        }

        #region Constructors

        private static HTMLElement Head(QualifiedName qname, Document document)
        {
            HTMLElement head = new HTMLElement(qname, document);

            return head;
        }

        #endregion

        public override T Create<T>(QualifiedName qname, Document document)
        {
            ConstructionHandler handler;

            if (Constructors.TryGetValue(qname.LocalName, out handler))
            {
                return handler(qname, document) as T;
            }

            return base.Create<T>(qname, document);
        }
    }
}
