using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;

namespace Yourgan.Core.Render
{
    public class RenderText : Primitive
    {
        public RenderText(Node node)
            : base(node)
        {
        }

        public override int MinPreferredWidth
        {
            get
            {
                return base.MinPreferredWidth;
            }
        }

        public override int MaxPreferredWidth
        {
            get
            {

                return base.MaxPreferredWidth;
            }
        }


    }
}
