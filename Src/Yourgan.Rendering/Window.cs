using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Parser;
using System.Drawing;

namespace Yourgan.Rendering
{
    public class Window
    {
        public Window()
        {
            this.document = new Document(this);
            this.parent = this;
        }

        public event Action Change;

        internal void OnChange()
        {
            if (Change != null)
                Change();
        }

        Document document;

        public Document Document
        {
            get
            {
                return document;
            }
        }

        RectangleF size;

        public RectangleF Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;

                this.Document.PerformLayout();
            }
        }

        float innerWidth;

        public float InnerWidth
        {
            get
            {
                return this.size.Width;
            }
        }

        float innerHeight;

        public float InnerHeight
        {
            get
            {
                return this.size.Height;
            }
        }

        float screenX;

        public float ScreenX
        {
            get
            {
                return screenX;
            }
        }

        float screenY;

        public float ScreenY
        {
            get
            {
                return screenY;
            }
        }

        Window parent;

        public Window Parent
        {
            get
            {
                return parent;
            }
        }

        public void Paint(DrawingContext context)
        {
            context.Graphics.FillRectangle(SystemBrushes.Window, 0, 0, this.size.Width, this.size.Height);

            this.document.Paint(context);
        }

        private void LoadHtml(object o)
        {
            // Status("Parsing");

            this.document = new Document(this);

            using (DocumentStream documentStream = new DocumentStream(this.document.XmlDocument))
            {
                using (System.IO.Stream html = o as System.IO.Stream)
                {
                    using (System.IO.StreamReader htmlReader = new System.IO.StreamReader(html, documentStream.Encoding))
                    {
                        int bufferSize = 8192;
                        char[] buffer = new char[8192];

                        while (bufferSize > 0)
                        {
                            bufferSize = htmlReader.Read(buffer, 0, bufferSize);

                            documentStream.Write(buffer, 0, bufferSize);
                        }
                    }
                }
            }

            this.Document.PerformLayout();
            // Status("Completed");
        }

        public void Load(string url)
        {
            System.Net.WebClient client = new System.Net.WebClient();

            System.IO.Stream stream = client.OpenRead(url);

            System.Threading.ThreadPool.QueueUserWorkItem(LoadHtml, stream);
        }

        public void Load(System.IO.Stream stream)
        {
            System.Threading.ThreadPool.QueueUserWorkItem(LoadHtml, stream);
        }
    }
}
