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


    }
}
