﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yourgan.Core.Page;
using Yourgan.Core.CSS;
using Yourgan.Core.Render;

namespace Yourgan.Core.DOM
{
    public class Document : Node
    {
        public Document(Frame frame, System.Xml.XmlDocument doc)
            : base(null)
        {
            this.frame = frame;
            this.Document = this;
            this.Renderer = new View(this, this.Frame.View);
            this.xmlDocument = doc;
            this.xmlDocument.NodeChanged += NodeChanged;
            this.xmlDocument.NodeInserted += NodeChanged;
        }

        private void NodeChanged(object sender, System.Xml.XmlNodeChangedEventArgs e)
        {
            this.Frame.Page.Paint();
        }

        private StyleSelector styleSelector;

        public StyleSelector StyleSelector
        {
            get
            {
                if (styleSelector == null)
                {
                    styleSelector = new StyleSelector(this);
                }

                return styleSelector;
            }
        }

        private System.Xml.XmlDocument xmlDocument;

        public System.Xml.XmlDocument XmlDocument
        {
            get { return xmlDocument; }
        }

        private Node documentElement;

        public Node DocumentElement
        {
            get
            {
                return documentElement;
            }
        }

        private Frame frame;

        public Frame Frame
        {
            get
            {
                return frame;
            }
        }
    }
}