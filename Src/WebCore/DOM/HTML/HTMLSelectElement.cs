using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    public abstract class HTMLSelectElement : HTMLBaseInputElement
    {
        public abstract int SelectedIndex
        {
            get;
            set;
        }

        public abstract string Value
        {
            get;
            set;
        }

        public abstract int Length
        {
            get;
            set;
        }

        public abstract HTMLOptionsCollection Options
        {
            get;
        }

        public abstract bool Multiple
        {
            get;
            set;
        }

        public abstract int Size
        {
            get;
            set;
        }

        public abstract void Add(HTMLElement element, HTMLElement before);

        public abstract void Remove(int index);

    }
}
