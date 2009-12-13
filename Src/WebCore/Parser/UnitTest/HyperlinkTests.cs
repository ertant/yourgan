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
using NUnit.Framework;

namespace Yourgan.Parser.UnitTest
{
    [TestFixture]
    public class HyperlinkTests : FixtureBase
    {
        [Test]
        public void ImpliedImgTag()
        {
            string html = "<HTML><BODY><div><a href=\"test\"><img src=\"img1\"></a></div></BODY></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("head", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("BODY", doc.DocumentElement.FirstChild.NextSibling.LocalName);
            Assert.AreEqual("div", doc.DocumentElement.FirstChild.NextSibling.FirstChild.LocalName);
            Assert.AreEqual("a", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.LocalName);
            Assert.AreEqual("img", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.LocalName);
        }

        [Test]
        public void ImpliedBodyTag()
        {
            string html = "<!doctype html><html><head><title>Google</title></head><body><div id=xjsc></div><div id=gbar><nobr><b class=gb1>Web</b> <a href=\"http://images.google.com.tr/imghp?hl=tr&tab=wi\" class=gb1>Görseller</a> <a href=\"http://news.google.com.tr/nwshp?hl=tr&tab=wn\" class=gb1>Haberler</a> <a href=\"http://groups.google.com.tr/grphp?hl=tr&tab=wg\" class=gb1>Gruplar</a> <a href=\"http://blogsearch.google.com.tr/?hl=tr&tab=wb\" class=gb1>Bloglar</a> <a href=\"http://translate.google.com.tr/?hl=tr&tab=wT\" class=gb1>Çeviri</a> <a href=\"http://mail.google.com/mail/?hl=tr&tab=wm\" class=gb1>Gmail</a> <a href=\"http://www.google.com.tr/intl/tr/options/\" aria-haspopup=true class=gb3><u>diğer</u> <small>&#9660;</small></a><div id=gbi><a href=\"http://www.google.com/calendar/render?hl=tr&tab=wc\" class=gb2>Takvim</a> <a href=\"http://picasaweb.google.com.tr/home?hl=tr&tab=wq\" onclick=gbar.qs(this) class=gb2>Fotoğraflar</a> <a href=\"http://docs.google.com/?hl=tr&tab=wo\" class=gb2>Dokümanlar</a> <a href=\"http://www.google.com.tr/reader/view/?hl=tr&tab=wy\" class=gb2>Reader</a> <a href=\"http://sites.google.com/?hl=tr&tab=w3\" class=gb2>Sites</a> <div class=gb2><div class=gbd></div></div><a href=\"http://www.google.com.tr/intl/tr/options/\" class=gb2>daha fazlası &raquo;</a> </div></nobr></div>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual(7, doc.DocumentElement.SelectNodes("//*[@class='gb1']").Count);
        }
    }
}
