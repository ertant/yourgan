using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.HtmlClient
{
    public class Field
    {
        public string Name { get; set; }

        public FieldType Type { get; set; }

        public int MaxLength { get; set; }

        public bool ReadOnly { get; set; }

        public string Value { get; set; }
    }
}
