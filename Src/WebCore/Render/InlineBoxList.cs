using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render
{
    public class InlineBoxList : Collection<InlineBox>
    {
        public InlineBoxList(Primitive owner)
        {
            this.owner = owner;
        }

        private Primitive owner;

        public Primitive Owner
        {
            get
            {
                return owner;
            }
        }
    }
}
