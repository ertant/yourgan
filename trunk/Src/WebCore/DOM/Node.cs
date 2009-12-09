using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.Render;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.DOM
{
    public abstract class Node
    {
        protected Node(Document document)
        {
            this.ownerDocument = document;
        }

        public abstract string NodeName
        {
            get;
        }

        public abstract string NodeValue
        {
            get;
            set;
        }

        public abstract NodeType NodeType
        {
            get;
        }

        public abstract string LocalName
        {
            get;
        }

        public abstract NodeType Type
        {
            get;
        }

        public abstract Node ParentNode
        {
            get;
        }

        public abstract NodeList ChildNodes
        {
            get;
        }

        public abstract Node FirstChild
        {
            get;
        }

        public abstract Node LastChild
        {
            get;
        }

        public abstract Node PreviousSibling
        {
            get;
        }

        public abstract Node NextSibling
        {
            get;
        }

        public virtual NamedNodeMap Attributes
        {
            get
            {
                return null;
            }
        }

        public abstract string NamespaceURI
        {
            get;
        }

        public abstract string Prefix
        {
            get;
        }

        public virtual string BaseURI
        {
            get
            {
                Node parent = this.ParentNode;

                while (parent != null)
                {
                    switch (parent.NodeType)
                    {
                        case NodeType.EntityReference:
                            return parent.ChildBaseURI;
                        case NodeType.Document:
                        case NodeType.Entity:
                        case NodeType.Attribute:
                            return parent.BaseURI;
                    }

                    parent = parent.ParentNode;
                }

                return string.Empty;
            }
        }

        public abstract string TextContent
        {
            get;
        }

        private Document ownerDocument;

        public Document OwnerDocument
        {
            get
            {
                return ownerDocument;
            }
            protected set
            {
                ownerDocument = value;
            }
        }

        public Node InsertBefore(Node newChild, Node refChild)
        {
            throw new NotImplementedException();
        }

        public Node ReplaceChild(Node newChild, Node oldChild)
        {
            throw new NotImplementedException();
        }

        public Node RemoveChild(Node oldChild)
        {
            throw new NotImplementedException();
        }

        public Node AppendChild(Node newChild)
        {
            throw new NotImplementedException();
        }

        public abstract bool HasChildNodes();

        public abstract Node CloneNode(bool deep);

        public void Normalize()
        {
            throw new NotImplementedException();
        }

        public bool IsSupported(string feature, string version)
        {
            throw new NotImplementedException();
        }

        public DocumentPosition ComparePosition(Node node)
        {
            throw new NotImplementedException();
        }

        public bool IsSameNode(Node node)
        {
            throw new NotImplementedException();
        }

        public string LookupPrefix(string namespaceUri)
        {
            throw new NotImplementedException();
        }

        public bool IsDefaultNamespace(string namespaceUri)
        {
            throw new NotImplementedException();
        }

        public bool LookupNamespaceUri(string prefix)
        {
            throw new NotImplementedException();
        }

        public bool IsEqualNode(Node arg)
        {
            throw new NotImplementedException();
        }

        public object GetFeature(string feature, string version)
        {
            throw new NotImplementedException();
        }

        // getUserData
        // setUserData

        private Primitive renderer;

        public Primitive Renderer
        {
            get
            {
                return renderer;
            }
            protected set
            {
                renderer = value;
            }
        }

        public bool RendererIsNeeded(StyleData style)
        {
            return (this.OwnerDocument.DocumentElement == this) || (style.DisplayStyle != DisplayStyle.None);
        }

        public void CreateRendererIfNeeded()
        {

        }

        public StyleData ResolveStyle()
        {
            return this.ownerDocument.StyleSelector.ResolveStyle(this as Element);
        }
    }
}
