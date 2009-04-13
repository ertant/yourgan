using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public interface IRectangular
    {
        int X
        {
            get; 
            set;
        }

        int Y
        {
            get;
            set;
        }

        int Width
        {
            get; 
            set;
        }

        int Height
        {
            get;
            set;
        }
    }
}
