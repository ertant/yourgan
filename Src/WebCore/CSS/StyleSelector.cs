using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.DOM;
using Yourgan.Core.Render.Style;

namespace Yourgan.Core.CSS
{
    public class StyleSelector
    {
        public StyleSelector(Document document)
        {

        }

        public StyleData ResolveStyle(Element element)
        {
            if (element == null)
                throw new ArgumentNullException("element");

            // TODO : implement
            return new StyleData();
        }
    }
}
