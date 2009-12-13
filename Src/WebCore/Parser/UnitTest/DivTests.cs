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
    public class DivTests : FixtureBase
    {
        [Test]
        public void DivInMisnestedTable()
        {
            string html = "<table><div align=\"left\">some text</div></table>";

            int unexpectedTagCount = 0;
            int totalErrors = 0;

            System.Xml.XmlDocument doc = LoadDocument(html, delegate(object sender, EntityErrorEventArgs args)
                                                            {
                                                                totalErrors++;

                                                                if (args.Code == EntityErrorCode.UnexpectedTag)
                                                                    unexpectedTagCount++;
                                                            });

            Assert.AreEqual(3, totalErrors);
            Assert.AreEqual(3, unexpectedTagCount);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("html", doc.DocumentElement.LocalName);
            Assert.AreEqual("head", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("body", doc.DocumentElement.FirstChild.NextSibling.LocalName);
            Assert.AreEqual("table", doc.DocumentElement.FirstChild.NextSibling.FirstChild.LocalName);
            Assert.AreEqual("div", doc.DocumentElement.FirstChild.NextSibling.FirstChild.NextSibling.LocalName);
            Assert.AreEqual("some text", doc.DocumentElement.FirstChild.NextSibling.FirstChild.NextSibling.InnerText);
        }

        [Test]
        public void DoubleDiv()
        {
            string html = "<html><body><div>test</div><div>zzz</div></body></html>";

            int unexpectedTagCount = 0;
            int totalErrors = 0;

            System.Xml.XmlDocument doc = LoadDocument(html, delegate(object sender, EntityErrorEventArgs args)
            {
                totalErrors++;

                if (args.Code == EntityErrorCode.UnexpectedTag)
                    unexpectedTagCount++;
            });

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

        }

        [Test]
        public void DivWithTwoSpan()
        {
            string html = @"<div><span>span1</span><span>span2</span></div>";

            int unexpectedTagCount = 0;
            int totalErrors = 0;

            System.Xml.XmlDocument doc = LoadDocument(html, delegate(object sender, EntityErrorEventArgs args)
            {
                totalErrors++;

                if (args.Code == EntityErrorCode.UnexpectedTag)
                    unexpectedTagCount++;
            });

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            System.Xml.XPath.XPathNavigator nav = doc.CreateNavigator();

            Eval(doc, "/h:html/h:body/h:div/span[1]", "span1");
            Eval(doc, "/h:html/h:body/h:div/span[2]", "span2");
        }
    }
}
