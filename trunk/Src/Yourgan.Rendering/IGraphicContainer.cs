using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public interface IGraphicContainer
    {
        GraphicObjectCollection Childs
        {
            get;
        }
    }
}
