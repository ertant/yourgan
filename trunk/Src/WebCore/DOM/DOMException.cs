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
    public class DOMException : Exception
    {
        public DOMException(DOMError errorCode)
        {
            this.errorCode = errorCode;
        }

        public DOMException(string message, DOMError errorCode)
            : base(message)
        {
            this.errorCode = errorCode;
        }

        private DOMError errorCode;

        public DOMError ErrorCode
        {
            get
            {
                return errorCode;
            }
        }
    }

    public enum DOMError
    {
        IndexSize = 1,
        StringSize = 2,
        HierarchyRequest = 3,
        WrongDocument = 4,
        InvalidCharacter = 5,
        NoDataAllowed = 6,
        NoModificationAllowed = 7,
        NotFound = 8,
        NotSupported = 9,
        InUseAttribute = 10,
        InvalidState = 11,
        SyntaxError = 12,
        InvalidModification = 13,
        NamespaceError = 14,
        InvalidAccess = 15,
        ValidationError = 16,
        TypeMismatch = 17
    }
}
