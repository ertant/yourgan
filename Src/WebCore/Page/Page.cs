using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.Page
{
    public class Page
    {
        private Frame mainFrame;

        public Frame MainFrame
        {
            get { return mainFrame; }
            set { mainFrame = value; }
        }

        private IHostWindow hostWindow;

        public IHostWindow HostWindow
        {
            get
            {
                return hostWindow;
            }
            set
            {
                hostWindow = value;
            }
        }
    }
}
