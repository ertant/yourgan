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
using System.Windows.Forms;

namespace Yourgan.Rendering.WindowsForms.Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SetStatus = new Action<string>(Status);

            panel1.Window = this.window;
        }

        Window window = new Window();

        protected override void OnLoad(EventArgs e)
        {
            string html = "";

            //html = @"<html><body><div>test</div><div>zzz</div></body></html>";
            //html = @"<html><body><div>div1</div><span>sp1</span><span>sp2</span><div>div2</div><span>sp3</span><span>sp4</span></body></html>";
            html = @"<html><body>
<div>duz yazi</div>
<div>aha bi duz yazi ŞÜKELA ÇAÇİK</div>
<div>duz bi yazi aha</div>
<div>sonsuzlara zartlarim bak ismayil.</div>
<div>
<span>spa<span>kocaman kocaman kirpiler</span></span><span>zip zip span</span>
<span>bukerim zamani kalirsin oyle bak</span>
<div>araya kacan div olsun buda</div>
<span>spa spa spa</span><span>seker bir sipasin sen</span>
</div>
</body></html>";

            /*html = @"<html><body>
<div>
<p>uzun paragraf kimine gore nedendir bu 
sence uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence 
uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence 
uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence 
uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence 
uzun paragraf kimine gore nedendir bu sence uzun paragraf kimine gore nedendir bu sence </p>
</div>
</body></html>";
             */

            //html = @"<html><body>test1 <a href=""http://images.google.com.tr/imghp?hl=tr&tab=wi"" onclick=gbar.qs(this) class=gb1>Görseller</a> test2</body></html>";
            //html = @"<html><body>test1 &nbsp; test2</body></html>";
            html = "<!doctype html><html><head><title>Google</title></head><body><div id=xjsc></div><div id=gbar><nobr><b class=gb1>Web</b> <a href=\"http://images.google.com.tr/imghp?hl=tr&tab=wi\" class=gb1>Görseller</a> <a href=\"http://news.google.com.tr/nwshp?hl=tr&tab=wn\" class=gb1>Haberler</a> <a href=\"http://groups.google.com.tr/grphp?hl=tr&tab=wg\" class=gb1>Gruplar</a> <a href=\"http://blogsearch.google.com.tr/?hl=tr&tab=wb\" class=gb1>Bloglar</a> <a href=\"http://translate.google.com.tr/?hl=tr&tab=wT\" class=gb1>Çeviri</a> <a href=\"http://mail.google.com/mail/?hl=tr&tab=wm\" class=gb1>Gmail</a> <a href=\"http://www.google.com.tr/intl/tr/options/\" aria-haspopup=true class=gb3><u>diğer</u> <small>&#9660;</small></a><div id=gbi><a href=\"http://www.google.com/calendar/render?hl=tr&tab=wc\" class=gb2>Takvim</a> <a href=\"http://picasaweb.google.com.tr/home?hl=tr&tab=wq\" onclick=gbar.qs(this) class=gb2>Fotoğraflar</a> <a href=\"http://docs.google.com/?hl=tr&tab=wo\" class=gb2>Dokümanlar</a> <a href=\"http://www.google.com.tr/reader/view/?hl=tr&tab=wy\" class=gb2>Reader</a> <a href=\"http://sites.google.com/?hl=tr&tab=w3\" class=gb2>Sites</a> <div class=gb2><div class=gbd></div></div><a href=\"http://www.google.com.tr/intl/tr/options/\" class=gb2>daha fazlası &raquo;</a> </div></nobr></div>";


            //html = System.IO.File.ReadAllText("d:\\small.html");

            System.IO.MemoryStream str = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(html));

            window.Load(str);

            base.OnLoad(e);
        }

        private Action<string> SetStatus;

        private void Status(string text)
        {
            if (label1.InvokeRequired)
                label1.Invoke(SetStatus, text);
            else
                label1.Text = text;
        }

        private void go_Click(object sender, EventArgs e)
        {
            string tmpAddress = address.Text;

            if (!tmpAddress.StartsWith("http://") && !tmpAddress.StartsWith("file:///"))
                tmpAddress = "http://" + tmpAddress;

            window.Load(new Uri(tmpAddress));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = window.Document.XmlDocument.OuterXml;
        }
    }
}
