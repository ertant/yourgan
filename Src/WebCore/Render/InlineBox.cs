using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render
{
    public class InlineBox
    {
        public InlineBox(Primitive owner)
        {
            this.owner = owner;
        }

        private Primitive owner;

        public Primitive Owner
        {
            get { return owner; }
        }

        private InlineBox parent;

        public InlineBox Parent
        {
            get { return parent; }
            set { parent = value; }
        }

        public bool IsLineBreak
        {
            get
            {
                return false;
            }
        }
    }
}
