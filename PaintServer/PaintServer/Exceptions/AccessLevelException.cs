using System;

namespace AskMe.Common.Exceptions
{
    public class AccessLevelException : Exception
    {
        public AccessLevelException() { }

        public AccessLevelException(string message) : base(message) { }
    }
}
