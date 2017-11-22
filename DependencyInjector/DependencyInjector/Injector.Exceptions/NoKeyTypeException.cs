using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class NoKeyTypeException : Exception
    {
        public NoKeyTypeException() : base()
        {

        }
        public NoKeyTypeException(string message) : base(message)
        {

        }
        public NoKeyTypeException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public NoKeyTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
