using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.UI
{
    public class ScrollbarValueChangeEventArgs : EventArgs
    {
        public ScrollbarValueChangeEventArgs(Scrollbar scrollbar, int value)
        {
            this.scrollbar = scrollbar;
            this.value = value;
        }

        private Scrollbar scrollbar;

        public Scrollbar Scrollbar
        {
            get { return scrollbar; }
        }

        private int value;

        public int Value
        {
            get { return value; }
        }
    }

    public delegate void ScrollbarValueChangeHandler(object sender, ScrollbarValueChangeEventArgs arg);
}
