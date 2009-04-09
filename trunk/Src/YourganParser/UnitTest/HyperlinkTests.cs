using System;
using System.Collections.Generic;
using System.Text;
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
    }
}
