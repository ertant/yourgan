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
