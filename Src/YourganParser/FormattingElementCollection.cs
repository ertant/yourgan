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
