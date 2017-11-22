using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class InvalidTypeException : Exception
    {
        public InvalidTypeException() : base()
        {

        }
        public InvalidTypeException(string message) : base(message)
        {

        }
        public InvalidTypeException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public InvalidTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
