using System;
using System.Collections.Generic;
using System.Text;

namespace Yourgan.Parser
{
    public class DocumentStream : System.IO.Stream
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

        public override void Write(byte[] buffer, int offset, int count)
        {
            tagTokenization.Parse(buffer, offset, count);
        }

        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override bool CanSeek
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override void Flush()
        {

        }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }

        public override long Seek(long offset, System.IO.SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }
    }
}
