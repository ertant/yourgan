namespace Yourgan.Core.DOM
{
    public class QualifiedName
    {
        public QualifiedName(string prefix, string localName, string namespaceURI)
        {
            this.prefix = prefix;
            this.localName = localName;
            this.namespaceURI = namespaceURI;
        }

        private string prefix;

        public string Prefix
        {
            get
            {
                return prefix;
            }
        }

        string localName;

        public string LocalName
        {
            get
            {
                return localName;
            }
        }

        string namespaceURI;

        public string NamespaceURI
        {
            get
            {
                return namespaceURI;
            }
        }

        int hashCode = -1;

        public override int GetHashCode()
        {
            if (hashCode == -1)
            {
                string tmp = this.prefix + this.localName + this.namespaceURI;

                hashCode = tmp.GetHashCode();
            }

            return hashCode;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.prefix))
                return prefix + ":" + localName;

            return localName;
        }
    }
}
