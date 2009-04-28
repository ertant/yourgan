﻿using System;
using System.Collections.Generic;
using System.Text;
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
    }
}