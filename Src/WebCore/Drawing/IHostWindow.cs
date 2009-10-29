using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Yourgan.Core.Drawing
{
    public interface IHostWindow
    {
        /// <summary>
        /// Gets the size of window
        /// </summary>
        Size Size
        {
            get;
        }

        event EventHandler SizeChanged;

        IPlatform GetPlatform();
    }
}
