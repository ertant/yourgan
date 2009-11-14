using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
