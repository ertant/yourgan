using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace Yourgan.Core.Render
{
    class PrimitiveList : Collection<Primitive>
    {
        public PrimitiveList(Primitive owner)
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
