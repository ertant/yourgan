using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public class ModelNode
    {
        public ModelNode(System.Xml.XmlElement element)
        {
            this.element = element;
        }

        private System.Xml.XmlElement element;

        public System.Xml.XmlElement Element
        {
            get
            {
                return element;
            }
        }
    }
}
