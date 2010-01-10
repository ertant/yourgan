using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.CSS
{
    public class StyleSheet
    {
        private string type;

        public string Type
        {
            get
            {
                return type;
            }
        }

        private string href;

        public string HRef
        {
            get
            {
                return href;
            }
        }

        public Node OwnerNode
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public StyleSheet ParentStyleSheet
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Title
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public MediaList Media
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        private bool disabled;

        public bool Disabled
        {
            get
            {
                return disabled;
            }
            set
            {
                disabled = value;
            }
        }
    }
}
