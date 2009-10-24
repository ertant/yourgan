using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;
using Yourgan.Parser;

namespace TestApp2
{
    class BrowserView : System.Windows.Forms.Panel, Yourgan.Core.Page.IHostWindow
    {
        public BrowserView()
        {

        }

        public void Load(string uri)
        {
            System.Net.WebClient client = new System.Net.WebClient();

            System.Xml.XmlDocument doc = new XmlDocument();

            Page page = new Page();

            page.HostWindow = this;

            Frame frame = new Frame(page);

            Document document = new Document(frame, doc);

            frame.Document = document;

            using (DocumentStream documentStream = new DocumentStream(document.XmlDocument))
            {
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

        #region IHostWindow Members

        System.Drawing.Rectangle Yourgan.Core.Page.IHostWindow.Bounds
        {
            get
            {
                return this.ClientRectangle;
            }
        }

        #endregion
    }
}
