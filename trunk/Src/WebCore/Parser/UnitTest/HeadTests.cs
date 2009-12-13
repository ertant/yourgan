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
    public class HeadTests : FixtureBase
    {
        [Test]
        public void SimpleTest()
        {
            string html = "<HTML><HEAD></HEAD></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(1, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("HEAD", doc.DocumentElement.FirstChild.LocalName);
        }

        [Test]
        public void HeadWithoutEndTag()
        {
            string html = "<HTML><HEAD></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(1, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("HEAD", doc.DocumentElement.FirstChild.LocalName);
        }

        [Test]
        public void HeadWithBody()
        {
            string html = "<HTML><HEAD><BODY></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("HEAD", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("BODY", doc.DocumentElement.FirstChild.NextSibling.LocalName);
        }

        [Test]
        public void NonSelfClosedLinkTest()
        {
            string html = "<HTML><HEAD><link rel=stylesheet type=\"text/css\" href=\"test.css\"></HEAD><BODY></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("HEAD", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("BODY", doc.DocumentElement.FirstChild.NextSibling.LocalName);
        }

        [Test]
        public void SelfClosedLinkTest()
        {
            string html = "<HTML><HEAD><link rel=stylesheet type=\"text/css\" href=\"test.css\"/></HEAD><BODY></HTML>";

            System.Xml.XmlDocument doc = LoadDocument(html);

            Assert.AreEqual(2, doc.DocumentElement.ChildNodes.Count);

            Assert.AreEqual("HEAD", doc.DocumentElement.FirstChild.LocalName);
            Assert.AreEqual("BODY", doc.DocumentElement.FirstChild.NextSibling.LocalName);
        }
    }
}
