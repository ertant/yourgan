using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public class GraphicContainer : GraphicObject, IGraphicContainer
    {
        private GraphicObjectCollection childs;

        public GraphicObjectCollection Childs
        {
            get
            {
                if (childs == null)
                {
                    childs = new GraphicObjectCollection();
                }

                return childs;
            }
        }
    }
}
