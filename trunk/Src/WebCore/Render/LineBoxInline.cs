using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render
{
    public class LineBoxInline
    {
        public LineBoxInline(Primitive owner)
        {
            this.owner = owner;
        }

        private Primitive owner;

        public Primitive Owner
        {
            get { return owner; }
        }
    }
}
