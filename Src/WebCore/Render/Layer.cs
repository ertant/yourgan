using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Render
{
    class Layer
    {
        public Layer(Box owner)
        {
            this.owner = owner;
        }

        private Box owner;

        public Box Owner
        {
            get
            {
                return owner;
            }
        }
    }
}
