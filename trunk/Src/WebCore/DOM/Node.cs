using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.Render;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.DOM
{
    // http://www.w3.org/TR/2004/REC-DOM-Level-3-Core-20040407/core.html#ID-1950641247
    public abstract class Node
    {
        protected Node()
        {
        }

        protected Node(Document document)
        {
            this.ownerDocument = document;
        }

        public abstract string NodeName
        {
            get;
        }

        public virtual string NodeValue
        {
            get
            {
                return null;
            }
            set
            {
                throw new DOMException(Strings.CannotSetNodeValue);
            }
        }

        public abstract NodeType NodeType
        {
            get;
        }

        public abstract string LocalName
        {
            get;
        }

        public Node ParentNode
        {
            get
            {
                if (parentNodeItem != null)
                {
                    return this.ParentNodeList.Owner;
                }

                return null;
            }
        }

        internal NodeList ParentNodeList
        {
            get
            {
                // fix here. remove unneccesary cast.
                return ((NodeList)parentNodeItem.List);
            }
        }

        LinkedListNode<Node> parentNodeItem;

        internal LinkedListNode<Node> ParentNodeItem
        {
            get
            {
                return parentNodeItem;
            }
            set
            {
                parentNodeItem = value;
            }
        }

        NodeList childNodes;

        public NodeList ChildNodes
        {
            get
            {
                if (childNodes == null)
                    childNodes = new NodeList(this);

                return childNodes;
            }
        }

        public Node FirstChild
        {
            get
            {
                if (childNodes.First != null)
                    return childNodes.First.Value;
                else
                    return null;
            }
        }

        public Node LastChild
        {
            get
            {
                if (childNodes.Last != null)
                    return childNodes.Last.Value;
                else
                    return null;
            }
        }

        public Node PreviousSibling
        {
            get
            {
                if ((this.ParentNodeItem != null) && (this.ParentNodeItem.Previous != null))
                {
                    return this.ParentNodeItem.Previous.Value;
                }

                return null;
            }
        }

        public Node NextSibling
        {
            get
            {
                if ((this.ParentNodeItem != null) && (this.ParentNodeItem.Next != null))
                {
                    return this.ParentNodeItem.Next.Value;
                }

                return null;
            }
        }

        public virtual NamedNodeMap Attributes
        {
            get
            {
                return null;
            }
        }

        public virtual string NamespaceURI
        {
            get
            {
                return null;
            }
        }

        public virtual string Prefix
        {
            get
            {
                return null;
            }
            set
            {
            }
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

        public bool HasChildNodes()
        {
            return childNodes.Count > 0;
        }

        public virtual bool HasAttributes()
        {
            return false;
        }

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
