using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public class FormattingElement
    {
        public FormattingElement(System.Xml.XmlElement element)
        {
            this.element = element;
            this.isMarker = false;
        }

        public FormattingElement()
        {
            this.isMarker = true;
        }

        System.Xml.XmlElement element;

        public System.Xml.XmlElement Element
        {
            get
            {
                return element;
            }
        }

        bool isMarker;

        public bool IsMarker
        {
            get
            {
                return isMarker;
            }
        }
    }
}
