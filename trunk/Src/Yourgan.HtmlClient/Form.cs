using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Yourgan.Parser;
using System.Xml;
using System.IO;
using System.Xml.XPath;

namespace Yourgan.HtmlClient
{
    class Form
    {
        public Form()
        {
            this.Method = "GET";
        }

        public string Name { get; set; }

        public string Action { get; set; }

        public string Method { get; set; }

        private List<Field> fields;

        public List<Field> Fields
        {
            get
            {
                if (fields == null)
                {
                    fields = new List<Field>();
                }

                return fields;
            }
        }

        public static IEnumerable<Form> GetForm(Stream inputStream, int bufferSize)
        {
            XmlDocument doc = new XmlDocument();

            using (DocumentStream outputStream = new DocumentStream(doc))
            {
                byte[] buffer = new byte[bufferSize];

                while (bufferSize > 0)
                {
                    bufferSize = inputStream.Read(buffer, 0, bufferSize);

                    outputStream.Write(buffer, 0, bufferSize);
                }
            }

            List<Form> forms = new List<Form>();

            XPathNavigator nav = doc.CreateNavigator();

            foreach (XPathNavigator formNode in nav.Select("//form"))
            {
                Form form = new Form();

                form.Name = formNode.GetAttribute("name", "");
                form.Action = formNode.GetAttribute("action", "");
                form.Method = formNode.GetAttribute("method", "");

                foreach (XPathNavigator inputNode in formNode.Select("//input|//textarea"))
                {
                    Field field = new Field();

                    field.Name = inputNode.GetAttribute("name", "");

                    string tmpType = inputNode.GetAttribute("type", "");

                    field.Type = (FieldType)Enum.Parse(typeof(FieldType), tmpType, true);
                    field.Value = inputNode.GetAttribute("value", "");

                    form.Fields.Add(field);

                    yield return form;
                }
            }
        }
    }
}
