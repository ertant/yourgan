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
using Yourgan.Core.Render;
using Yourgan.Core.UI;

namespace Yourgan.Core.Page
{
    public class FrameView : ScrollView
    {
        public FrameView(Frame frame)
        {
            this.frame = frame;
        }

        private Frame frame;

        public Frame Frame
        {
            get { return frame; }
        }

        public int LayoutWidth
        {
            get
            {
                return this.VisibleWidth;
            }
        }

        public int LayoutHeight
        {
            get
            {
                return this.VisibleHeight;
            }
        }

        public Box ContentRenderer
        {
            get
            {
                if (this.Frame.Document != null)
                {
                    return this.Frame.Document.Renderer as Box;
                }
                else
                {
                    return null;
                }
            }
        }

        public bool IsLayoutInvalid
        {
            get
            {
                if (this.ContentRenderer != null)
                    return this.ContentRenderer.IsLayoutInvalid;
                else
                    return false;
            }
        }

        public void PerformLayout()
        {
            if ((this.ContentRenderer != null) && (this.ContentRenderer.IsLayoutInvalid))
            {
                this.ContentRenderer.PerformLayout();

                this.Bounds = this.ContentRenderer.Frame;
            }
        }

        public void UpdateLayout(bool isInvalid)
        {
            if (this.ContentRenderer != null)
            {
                this.ContentRenderer.UpdateLayout(isInvalid);
            }
        }
    }
}
