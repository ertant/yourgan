using System;
using Yourgan.Core.Page;
using Yourgan.Core.CSS;
using Yourgan.Core.Render;

namespace Yourgan.Core.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#i-Document
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
                    if (this.documentType == null)
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

        protected internal override void OnChildAdded(Node node)
        {
            base.OnChildAdded(node);

            if (node.NodeType == NodeType.Element)
            {
                this.documentElement = node as Element;
            }
            else if (node.NodeType == NodeType.DocumentType)
            {
                this.documentType = node as DocumentType;
            }
        }

        protected internal override void OnChildRemoved(Node node)
        {
            base.OnChildRemoved(node);

            if (node.NodeType == NodeType.Element)
            {
                this.documentElement = null;
            }
            else if (node.NodeType == NodeType.DocumentType)
            {
                this.documentType = null;
            }
        }

        public Element CreateElement(string tagName)
        {
            QualifiedName qname = new QualifiedName(null, tagName, null);

            Element element = new Element(qname, this);

            return element;
        }

        public Element CreateElementNS(string namespaceURI, string qualifiedName)
        {
            QualifiedName qname = QualifiedName.Parse(qualifiedName, namespaceURI);

            Element element = new Element(qname, this);

            return element;
        }

        public DocumentFragment CreateDocumentFragment()
        {
            throw new NotImplementedException();
        }

        public Text CreateTextNode(string data)
        {
            Text text = new Text(this);

            text.Data = data;

            return text;
        }

        public Comment CreateComment(string data)
        {
            Comment comment = new Comment(this);

            comment.Data = data;

            return comment;
        }

        public CDATASection CreateCDataSection(string data)
        {
            CDATASection cdata = new CDATASection(this);

            cdata.Data = data;

            return cdata;
        }

        public ProcessingInstruction CreateProcessingInstruction(string target, string data)
        {
            ProcessingInstruction pi = new ProcessingInstruction(target, this);

            pi.Data = data;

            return pi;
        }

        public Attr CreateAttribute(string name)
        {
            QualifiedName qname = QualifiedName.Parse(name);

            Attr attr = new Attr(qname, this);

            return attr;
        }

        public Attr CreateAttributeNS(string namespaceURI, string qualifiedName)
        {
            QualifiedName qname = QualifiedName.Parse(qualifiedName, namespaceURI);

            Attr attr = new Attr(qname, this);

            return attr;
        }

        public EntityReference CreateEntityReference(string name)
        {
            throw new NotImplementedException();
        }

        private string documentURI;

        public string DocumentURI
        {
            get
            {
                return documentURI;
            }
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
