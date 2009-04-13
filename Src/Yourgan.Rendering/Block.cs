using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public class Block : RectangularContainer
    {
        public Block(ModelNode model)
        {
            this.model = model;
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }
    }
}
