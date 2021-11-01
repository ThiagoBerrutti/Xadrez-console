using System;

namespace Chess.Exceptions
{
    class CheckException : Exception
    {
        public CheckException(string message) : base(message) 
        {
        }
    }
}
