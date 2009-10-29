using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;
using Yourgan.Parser;
using System.Drawing;

using Yourgan.Core.Drawing;
using Yourgan.Core.Drawing.GDI;


namespace TestApp2
{
    class BrowserView : System.Windows.Forms.Panel, Yourgan.Core.Drawing.IHostWindow
    {
        public BrowserView()
        {

        }

        public void Load(string uri)
        {
            System.Xml.XmlDocument doc = new XmlDocument();

            Page page = new Page();

            page.HostWindow = this;

            Frame frame = new Frame(page);

            Document document = new Document(frame, doc);

            frame.Document = document;

            using (DocumentStream documentStream = new DocumentStream(document.XmlDocument))
            {
                System.Net.WebClient client = new System.Net.WebClient();

                using (System.IO.Stream html = client.OpenRead(uri))
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
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            this.platform.Render(e.Graphics, e.ClipRectangle);
        }

        #region IHostWindow Members

        Size Yourgan.Core.Drawing.IHostWindow.Size
        {
            get
            {
                return this.Size;
            }
        }

        event EventHandler Yourgan.Core.Drawing.IHostWindow.SizeChanged
        {
            add
            {
                this.SizeChanged += value;
            }
            remove
            {
                this.SizeChanged += value;
            }
        }

        GDIDrawingPlatform platform = new GDIDrawingPlatform();

        IDrawingPlatform Yourgan.Core.Drawing.IHostWindow.GetPlatform()
        {
            return platform;
        }

        #endregion
    }
}
