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

namespace Yourgan.Rendering
{
    public class FrameContext
    {
        public FrameContext()
        {
            this.document = new System.Xml.XmlDocument();
            this.document.NodeChanged += NodeHandler;
            this.document.NodeInserted += NodeHandler;
            this.document.NodeRemoved += NodeHandler;
        }

        private GraphicObject root;

        public GraphicObject Root
        {
            get
            {
                return this.root;
            }
        }

        private void NodeHandler(object sender, System.Xml.XmlNodeChangedEventArgs args)
        {
            XmlElement element = args.Node as XmlElement;

            if (element != null)
            {
                GraphicObject graphicElement = null;
                GraphicObject parent = null;

                if (this.root != null)
                {
                    this.Objects.TryGetValue(args.NewParent as XmlElement, out parent);
                }

                if (!this.Objects.TryGetValue(element, out graphicElement))
                {
                    graphicElement = this.Create(parent as GraphicContainer, element);
                }

                if (this.root == null)
                {
                    this.root = graphicElement;
                }

                ILayoutPerformer layout = graphicElement as ILayoutPerformer;

                if (layout != null)
                {
                    layout.DoLayout(this);
                }
            }
        }

        private System.Xml.XmlDocument document;

        public System.Xml.XmlDocument Document
        {
            get
            {
                return this.document;
            }
        }

        public GraphicObject Create(GraphicContainer parent, System.Xml.XmlElement element)
        {
            Block block = new Block(new ModelNode(element), parent);

            if (parent != null)
            {
                parent.Childs.Add(block);
            }

            this.Objects[element] = block;

            return block;
        }

        private Dictionary<System.Xml.XmlElement, GraphicObject> objects;

        public Dictionary<System.Xml.XmlElement, GraphicObject> Objects
        {
            get
            {
                if (this.objects == null)
                {
                    this.objects = new Dictionary<System.Xml.XmlElement, GraphicObject>();
                }

                return this.objects;
            }
        }
    }
}
