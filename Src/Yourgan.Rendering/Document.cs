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
    public class Document : GraphicContainer
    {
        public Document()
        {
            this.OwnerDocument = this;

            this.xmlDocument = new System.Xml.XmlDocument();
            this.xmlDocument.NodeChanged += NodeHandler;
            this.xmlDocument.NodeInserted += NodeHandler;
            this.xmlDocument.NodeRemoved += NodeHandler;
        }

        public event Action Change;

        private Html documentElement;

        public Html DocumentElement
        {
            get
            {
                return documentElement;
            }
        }

        private void NodeHandler(object sender, System.Xml.XmlNodeChangedEventArgs args)
        {
            GraphicObject graphicElement = null;
            GraphicObject parent = null;

            if ((args.NewParent != null) && (args.NewParent != xmlDocument))
            {
                this.Objects.TryGetValue(args.NewParent, out parent);
            }

            if (!this.Objects.TryGetValue(args.Node, out graphicElement))
            {
                graphicElement = this.Create(parent as GraphicContainer, args.Node);
            }

            if (graphicElement != null)
            {
                if (parent == null)
                {
                    parent = this;
                }

                GraphicContainer container = parent as GraphicContainer;

                if (container != null)
                {
                    container.Childs.Add(graphicElement);
                }

                if (Change != null)
                {
                    Change();
                }
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

        private GraphicObject CreateBlock(ModelNode node, DisplayMode mode)
        {
            Block block = new Block(node);

            block.Style.Display = mode;

            return block;
        }

        public GraphicObject Create(GraphicContainer parent, System.Xml.XmlNode element)
        {
            ModelNode node = new ModelNode(element);

            GraphicObject obj = null;

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
                            case "font":
                            case "span":
                                {
                                    obj = CreateBlock(node, DisplayMode.Inline);
                                    break;
                                }
                            case "a":
                                {
                                    obj = CreateBlock(node, DisplayMode.Inline);
                                    break;
                                }
                            default:
                                {
                                    Block block = new Block(node);

                                    obj = block;

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

        private Dictionary<System.Xml.XmlNode, GraphicObject> objects;

        public Dictionary<System.Xml.XmlNode, GraphicObject> Objects
        {
            get
            {
                if (this.objects == null)
                {
                    this.objects = new Dictionary<System.Xml.XmlNode, GraphicObject>();
                }

                return this.objects;
            }
        }

        private RectangleF documentSize;

        public RectangleF DocumentSize
        {
            get
            {
                return documentSize;
            }
            set
            {
                documentSize = value;

                if (this.documentElement != null)
                    this.documentElement.Body.Layout.Invalidate();
            }
        }

        public override float ClientLeft
        {
            get
            {
                return 0;
            }
        }

        public override float ClientTop
        {
            get
            {
                return 0;
            }
        }

        public override float ClientHeight
        {
            get
            {
                return this.documentSize.Height;
            }
        }

        public override float ClientWidth
        {
            get
            {
                return this.documentSize.Width;
            }
        }

        public override float PixelsHeight
        {
            get
            {
                return this.documentSize.Height;
            }
        }

        public override float PixelsWidth
        {
            get
            {
                return this.documentSize.Width;
            }
        }

        public override float OffsetLeft
        {
            get
            {
                return 0;
            }
        }

        public override float OffsetTop
        {
            get
            {
                return 0;
            }
        }

        public override float ScrollWidth
        {
            get
            {
                return this.ClientWidth;
            }
        }

        public override float ScrollHeight
        {
            get
            {
                return this.ClientHeight;
            }
        }

        protected internal override void OnChildrenAdded(IEnumerable<GraphicObject> objects)
        {
            base.OnChildrenAdded(objects);

            foreach (GraphicObject graphicObject in objects)
            {
                if (graphicObject is Html)
                {
                    this.documentElement = graphicObject as Html;
                }
            }
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            if (this.documentElement != null)
            {
                drawingContext.Graphics.FillRectangle(SystemBrushes.Window, this.ClientLeft, this.ClientTop, this.ClientWidth, this.ClientHeight);

                this.documentElement.Paint(drawingContext);
            }
        }
    }
}
