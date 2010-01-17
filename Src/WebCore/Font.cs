using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core
{
    public class Font
    {
        public Font(FontDescription description)
        {
            this.description = description;
        }

        public FontDescription description;

        public FontDescription Description
        {
            get
            {
                return description;
            }
        }
    }
}
