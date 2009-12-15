using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Yourgan.Core.DOM.HTML
{
    // http://www.w3.org/TR/2003/REC-DOM-Level-2-HTML-20030109/html.html#ID-26809268
    public abstract class HTMLDocument : Document
    {
        public abstract string Title
        {
            get;
            set;
        }

        public abstract string Referrer
        {
            get;
        }

        public abstract string Domain
        {
            get;
        }

        public abstract string URL
        {
            get;
        }

        public abstract HTMLElement Body
        {
            get;
            set;
        }

        public abstract HTMLCollection Images
        {
            get;
        }

        public abstract HTMLCollection Applets
        {
            get;
        }

        public abstract HTMLCollection Links
        {
            get;
        }

        public abstract HTMLCollection Forms
        {
            get;
        }

        public abstract HTMLCollection Anchors
        {
            get;
        }

        public string Cookie
        {
            get;
            set;
        }


        public abstract void Open();

        public abstract void Close();

        public abstract void Write(string text);

        public abstract void WriteLn(string text);

        public abstract NodeList GetElementsByName(string elementName);
    }
}
