using Yourgan.Core.Page;
using Yourgan.Core.CSS;
using Yourgan.Core.Render;

namespace Yourgan.Core.DOM
{
    public class Document : Node
    {
        public Document(Frame frame)
            : base(null)
        {
            this.frame = frame;
            this.OwnerDocument = this;
            this.Renderer = new View(this, this.Frame.View);
        }

        #region DOM

        public override string NodeName
        {
            get
            {
                return "#document";
            }
        }

        public override NodeType NodeType
        {
            get
            {
                return NodeType.Document;
            }
        }

        private DocumentType documentType;

        public DocumentType DocumentType
        {
            get
            {
                return documentType;
            }
        }

        private Element documentElement;

        public Element DocumentElement
        {
            get
            {
                return documentElement;
            }
        }

        protected override bool IsValidChildType(NodeType type)
        {
            switch (type)
            {
                case NodeType.Comment:
                case NodeType.ProcessingInstruction:
                    return true;
                case NodeType.DocumentType:
                    if (this.documentElement == null)
                        return true;
                    break;
                case NodeType.Element:
                    if (this.documentElement == null)
                        return true;
                    break;
                default:
                    break;
            }

            return false;
        }

        #endregion

        private StyleSelector styleSelector;

        public StyleSelector StyleSelector
        {
            get
            {
                if (styleSelector == null)
                {
                    styleSelector = new StyleSelector(this);
                }

                return styleSelector;
            }
        }

        private System.Xml.XmlDocument xmlDocument;

        public System.Xml.XmlDocument XmlDocument
        {
            get { return xmlDocument; }
        }

        private Frame frame;

        public Frame Frame
        {
            get
            {
                return frame;
            }
        }
    }
}
