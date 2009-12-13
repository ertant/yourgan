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

namespace Yourgan.Core.Parser.UnitTest
{
    [TestFixture]
    public class TableTests : FixtureBase
    {
        [Test]
        public void PlainTable()
        {
            string html = @"<html><body><table><tr><td>cell1</td></tr></table></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }

        [Test]
        public void MissingTrWithCloseTag()
        {
            string html = @"<html><body><table><td>cell1</td></tr></table></body></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }

        [Test]
        public void TrWithMissingCloseTag()
        {
            string html = @"<html><body><table><tr><td>cell1</td></html>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Eval(doc, "/h:html/h:body/h:table/h:tbody/h:tr/h:td/text()", "cell1");
        }

        [Test]
        public void TableWithDiv()
        {
            string html = "<table><tr><td><div align=\"left\">some text</div></td></tr></table>";

            int unexpectedTagCount = 0;
            int totalErrors = 0;

            System.Xml.XmlDocument doc = LoadDocument(html, delegate(object sender, EntityErrorEventArgs args)
                                                                {
                                                                    totalErrors++;

                                                                    if (args.Code == EntityErrorCode.UnexpectedTag)
                                                                        unexpectedTagCount++;
                                                                });

            Assert.AreEqual(0, totalErrors);
            Assert.AreEqual(0, unexpectedTagCount);
            
            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("html", doc.DocumentElement.LocalName);
            Assert.AreEqual("head", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("body", doc.DocumentElement.FirstChild.NextSibling.LocalName);
            Assert.AreEqual("table", doc.DocumentElement.FirstChild.NextSibling.FirstChild.LocalName);
            Assert.AreEqual("tbody", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.LocalName);
            Assert.AreEqual("tr", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.LocalName);
            Assert.AreEqual("td", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.LocalName);
            Assert.AreEqual("div", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.LocalName);
            Assert.AreEqual("some text", doc.DocumentElement.FirstChild.NextSibling.FirstChild.FirstChild.FirstChild.FirstChild.FirstChild.InnerText);
        }
    }
}


