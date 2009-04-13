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
using System.Diagnostics;

namespace Yourgan.Rendering
{
    [DebuggerDisplay("{Model.Element.Name}")]
    public class Block : RectangularContainer, ILayoutPerformer
    {
        public Block(ModelNode model, GraphicContainer parent)
        {
            this.model = model;
            this.parent = parent;
        }

        private GraphicContainer parent;

        public GraphicContainer Parent
        {
            get
            {
                return parent;
            }
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }

        public void DoLayout(FrameContext context)
        {
            PerformFlowLayout(context);
        }

        private void PerformFlowLayout(FrameContext context)
        {
            this.Childs.Clear();

            foreach (System.Xml.XmlElement childNode in this.Model.Childs)
            {
                GraphicObject child = context.Create(this, childNode);
            }
        }
    }
}
