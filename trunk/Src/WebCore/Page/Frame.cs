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
using Yourgan.Core.DOM;

namespace Yourgan.Core.Page
{
    public class Frame
    {
        public Frame(Page page)
        {
            this.page = page;
            this.view = new FrameView(this);
        }

        private Page page;

        public Page Page
        {
            get { return page; }
        }

        private Document document;

        public Document Document
        {
            get { return document; }
            set { document = value; }
        }

        private FrameView view;

        public FrameView View
        {
            get
            {
                return view;
            }
        }

        public Render.Primitive Renderer
        {
            get
            {
                return this.Document.Renderer;
            }
        }
    }
}
