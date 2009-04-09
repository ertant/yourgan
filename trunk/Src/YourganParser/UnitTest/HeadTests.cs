using System;
using System.Collections.Generic;
using System.Text;
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
