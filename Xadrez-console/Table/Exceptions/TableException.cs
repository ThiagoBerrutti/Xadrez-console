using System;

namespace TableNS.Exceptions
{
    class TableException : ApplicationException
    {
        public TableException(string message) : base(message)
        {            
        }
    }
}
