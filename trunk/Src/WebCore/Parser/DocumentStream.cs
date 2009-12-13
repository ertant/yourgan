// /*
// Yourgan
// Copyright (C) 2009  Ertan Tike
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// */
using System;
using System.Text;

namespace Yourgan.Parser
{
    public class DocumentStream : System.IO.TextWriter
    {
        TagTokenizerState tagTokenization;

        public DocumentStream(System.Xml.XmlDocument document)
        {
            this.document = document;
            this.tagTokenization = new TagTokenizerState(document);
        }

        public override void Close()
        {
            this.tagTokenization.Close();

            base.Close();
        }

        public event EventHandler<EntityErrorEventArgs> EntityError
        {
            add
            {
                this.tagTokenization.EntityGeneration.HTMLTokenization.EntityError += value;
            }
            remove
            {
                this.tagTokenization.EntityGeneration.HTMLTokenization.EntityError -= value;
            }
        }

        System.Xml.XmlDocument document;

        public System.Xml.XmlDocument Document
        {
            get
            {
                return document;
            }
        }

        public override void Write(char[] buffer, int offset, int count)
        {
            tagTokenization.Parse(buffer, offset, count);
        }

        public override void Write(char value)
        {
            base.Write(value);
        }

        public override Encoding Encoding
        {
            get
            {
                return tagTokenization.Encoding;
            }
        }
    }
}
