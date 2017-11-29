using System;
using System.Runtime.Serialization;

namespace KSR.Exceptions
{
    [Serializable]
    public class RemoveException : Exception
    {
        public RemoveException() : base()
        {

        }
        public RemoveException(string message) : base(message)
        {

        }
        public RemoveException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public RemoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
