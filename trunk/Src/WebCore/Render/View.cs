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
using System.Drawing;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.Render
{
    public class View : Block
    {
        public View(Node node)
            : base(node)
        {
            this.Style.Position = PositionStyle.Absolute;
            this.Layer = new Layer(this);
        }

        protected override void OnPaint(Yourgan.Core.Drawing.IGraphicsContext context)
        {
            base.OnPaint(context);

            if (this.IsLayoutInvalid)
            {
                this.PerformLayout();
            }

            context.FillRectangle(System.Drawing.Brushes.Red, this.Frame);
        }

        protected override void OnPerformLayout()
        {
            base.OnPerformLayout();

            this.Frame = new Rectangle(0, 0, 50, 50);

            this.UpdateLayout(false);
        }
    }
}
