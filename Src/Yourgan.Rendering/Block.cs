// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System.Diagnostics;
using System.Drawing;

namespace Yourgan.Rendering
{
    [DebuggerDisplay("{Model.Element.Name}")]
    public class Block : GraphicElement
    {
        public Block(ModelNode model)
        {
            this.model = model;
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }

        protected override void CorePaint(DrawingContext drawingContext)
        {
            base.CorePaint(drawingContext);

            drawingContext.PushTransform();

            drawingContext.Translate(this.OffsetLeft, this.OffsetTop);

            Pen pen = Pens.Red;

            if (this is Body)
                pen = Pens.Cyan;
            if (this.Style.Display == DisplayMode.Inline)
                pen = Pens.LawnGreen;

            drawingContext.Graphics.DrawRectangle(pen, 0, 0, this.OffsetWidth, this.OffsetHeight);

            drawingContext.Graphics.DrawRectangle(Pens.LightGray, this.Style.Padding.Left, this.Style.Padding.Top, this.OffsetWidth - this.Style.Padding.Right, this.OffsetHeight - this.Style.Padding.Top);

            drawingContext.PopTransform();
        }
    }
}
