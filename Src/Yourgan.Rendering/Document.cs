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
using System.Drawing;

namespace Yourgan.Rendering
{
    public class Document : GraphicNode
    {
        public Document(Window window)
        {
            this.OwnerDocument = this;
            this.defaultView = window;

            this.xmlDocument = new System.Xml.XmlDocument();
            this.xmlDocument.NodeChanged += NodeHandler;
            this.xmlDocument.NodeInserted += NodeHandler;
            this.xmlDocument.NodeRemoved += NodeHandler;
        }

        private Html documentElement;

        public Html DocumentElement
        {
            get
            {
                return documentElement;
            }
        }

        Window defaultView;

        public Window DefaultView
        {
            get
            {
                return defaultView;
            }
        }

        private void NodeHandler(object sender, System.Xml.XmlNodeChangedEventArgs args)
        {
            GraphicNode graphicElement;
            GraphicNode parent = null;

            if ((args.NewParent != null) && (args.NewParent != xmlDocument))
            {
                this.Objects.TryGetValue(args.NewParent, out parent);
            }

            if (!this.Objects.TryGetValue(args.Node, out graphicElement))
            {
                graphicElement = this.Create(args.Node);
            }

            if (graphicElement != null)
            {
                if (parent == null)
                {
                    parent = this;
                }

                parent.Childs.Add(graphicElement);

                this.DefaultView.OnChange();
            }
        }

        private XmlDocument xmlDocument;

        public XmlDocument XmlDocument
        {
            get
            {
                return this.xmlDocument;
            }
        }

        private GraphicNode CreateBlock(ModelNode node, DisplayMode mode)
        {
            Block block = new Block(node);

            block.Style.ElementStyle.Display = mode;

            return block;
        }

        public GraphicNode Create(System.Xml.XmlNode element)
        {
            ModelNode node = new ModelNode(element);

            GraphicNode obj = null;

            switch (element.NodeType)
            {
                case XmlNodeType.Element:
                    {
                        switch (element.LocalName)
                        {
                            case "html":
                                {
                                    obj = new Html(node);
                                    break;
                                }
                            case "body":
                                {
                                    obj = new Body(node);
                                    break;
                                }
                            case "div":
                                {
                                    obj = CreateBlock(node, DisplayMode.Block);
                                    break;
                                }
                            case "script":
                                {
                                    // do not create anything
                                    break;
                                }
                            default:
                                {
                                    obj = CreateBlock(node, DisplayMode.Inline);
                                    break;
                                }
                        }

                        break;
                    }
                case XmlNodeType.Text:
                    {
                        obj = new Word(node, element.Value, new Font());
                        break;
                    }
            }

            if (obj != null)
            {
                obj.OwnerDocument = this;

                this.Objects[element] = obj;
            }

            return obj;
        }

        private Dictionary<System.Xml.XmlNode, GraphicNode> objects;

        public Dictionary<System.Xml.XmlNode, GraphicNode> Objects
        {
            get
            {
                if (this.objects == null)
                {
                    this.objects = new Dictionary<System.Xml.XmlNode, GraphicNode>();
                }

                return this.objects;
            }
        }

        //private RectangleF documentSize;

        //public RectangleF DocumentSize
        //{
        //    get
        //    {
        //        return documentSize;
        //    }
        //    set
        //    {
        //        documentSize = value;

        //        if (this.documentElement != null)
        //            this.documentElement.Body.Layout.Invalidate();
        //    }
        //}

        public void PerformLayout()
        {
            if (this.DocumentElement != null)
            {
                this.DocumentElement.Body.Layout.Invalidate();
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicNode> affectedChilds)
        {
            base.OnChildrenAdded(affectedChilds);

            foreach (GraphicElement graphicObject in affectedChilds)
            {
                Html tmpHtml = graphicObject as Html;

                if (tmpHtml != null)
                {
                    this.documentElement = tmpHtml;
                }
            }
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            if (this.documentElement != null)
            {
                this.documentElement.Paint(drawingContext);
            }
        }
    }
}
