/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace Yourgan.Parser
{
    public class FormattingElementCollection
    {
        Stack<FormattingElement> elements = new Stack<FormattingElement>();

        public List<FormattingElement> Copy()
        {
            return new List<FormattingElement>(elements);
        }

        public FormattingElement Peek()
        {
            return elements.Peek();
        }

        public void Push(XmlElement element)
        {
            elements.Push(new FormattingElement(element));
        }

        public void PushMarker()
        {
            elements.Push(new FormattingElement());
        }

        public void ClearToMarker()
        {
            FormattingElement current = elements.Pop();

            while (!current.IsMarker)
                current = elements.Pop();
        }
    }
}
