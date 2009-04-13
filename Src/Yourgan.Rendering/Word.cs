using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Rendering
{
    public class Word : RectangularObject
    {
        public Word(ModelNode model, string text, Font font)
        {
            this.model = model;
            this.text = text;
            this.font = font;
        }

        private string text;

        public string Text
        {
            get
            {
                return text;
            }
        }

        private ModelNode model;

        public ModelNode Model
        {
            get
            {
                return model;
            }
        }

        private Font font;

        public Font Font
        {
            get
            {
                return font;
            }
        }
    }
}
