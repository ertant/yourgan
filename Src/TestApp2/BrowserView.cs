using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using Yourgan.Core.DOM;
using Yourgan.Core.Page;
using Yourgan.Parser;
using System.Drawing;

using Yourgan.Core.Drawing;
using Yourgan.Core.Drawing.GDI;
using System.Windows.Forms;


namespace TestApp2
{
    class BrowserView : System.Windows.Forms.Panel, Yourgan.Core.Drawing.IHostWindow
    {
        public BrowserView()
        {
            InitializeComponent();

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.UserPaint, true);
        }

        private void InternalLoad(System.IO.Stream reader)
        {
            System.Xml.XmlDocument doc = new XmlDocument();

            Page page = new Page();

            Document document = new Document(page.MainFrame, doc);

            page.MainFrame.Document = document;

            page.HostWindow = this;

            using (DocumentStream documentStream = new DocumentStream(document.XmlDocument))
            {
                using (System.IO.StreamReader htmlReader = new System.IO.StreamReader(reader, documentStream.Encoding))
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

            this.Invalidate();
        }

        public void LoadFile(string filePath)
        {
            using (System.IO.FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                InternalLoad(file);
            }
        }

        public void LoadHtml(string html)
        {
            using (System.IO.MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
            {
                InternalLoad(stream);
            }
        }

        public void Load(string uri)
        {
            System.Net.WebClient client = new System.Net.WebClient();

            using (System.IO.Stream html = client.OpenRead(uri))
            {
                InternalLoad(html);
            }
        }

        protected override void OnPaintBackground(System.Windows.Forms.PaintEventArgs e)
        {

        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            this.platform.Render(e.Graphics, e.ClipRectangle);
        }

        private System.Windows.Forms.Timer timer1;

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

        IDrawingPlatform IHostWindow.Platform
        {
            get
            {
                return platform;
            }
        }

        #endregion

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 250;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            this.ResumeLayout(false);

        }

        private System.ComponentModel.IContainer components;

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
