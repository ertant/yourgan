/*
Yourgan
Copyright (C) 2009  Ertan Tike

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/
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
