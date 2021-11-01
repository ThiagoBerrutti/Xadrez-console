using System;

namespace TableNS.Exceptions
{
    class TableException : Exception
    {
        public TableException(string message) : base(message)
        {            
        }
    }
}
