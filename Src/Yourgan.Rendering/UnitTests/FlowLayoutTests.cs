using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Xml;
using Yourgan.Parser;

namespace Yourgan.Rendering.UnitTests
{
    [TestFixture]
    public class FlowLayoutTests
    {
        [Test]
        public void SimpleTest()
        {
            string html = @"<html><body><div>test</div></body></html>";

            Document context = new Document();

            using (DocumentStream stream = new DocumentStream(context.XmlDocument))
            {
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(stream))
                {
                    writer.Write(html);
                }
            }
        }
    }
}
