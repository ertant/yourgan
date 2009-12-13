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
using System;

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

        public bool Matches(QualifiedName other)
        {
            if (this == other)
                return true;

            if ((this.localName == other.localName) && (this.namespaceURI == other.namespaceURI))
                return true;

            return false;
        }

        public static QualifiedName Parse(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            int pos = name.IndexOf(':');

            string prefix;
            string localName;

            if ((pos > 0) && (pos < name.Length - 1))
            {
                prefix = name.Substring(0, pos);
                localName = name.Substring(pos + 1);
            }
            else
            {
                prefix = null;
                localName = name;
            }

            return new QualifiedName(prefix, localName, null);
        }

        public static QualifiedName Parse(string name, string namespaceURI)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            int pos = name.IndexOf(':');

            string prefix;
            string localName;

            if ((pos > 0) && (pos < name.Length - 1))
            {
                prefix = name.Substring(0, pos);
                localName = name.Substring(pos + 1);
            }
            else
            {
                prefix = null;
                localName = name;
            }

            return new QualifiedName(prefix, localName, namespaceURI);
        }
    }
}
