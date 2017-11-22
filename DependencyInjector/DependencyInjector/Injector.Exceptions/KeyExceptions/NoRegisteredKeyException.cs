using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class NoRegisteredKeyException : Exception
    {
        public NoRegisteredKeyException() : base()
        {

        }
        public NoRegisteredKeyException(string message) : base(message)
        {

        }
        public NoRegisteredKeyException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public NoRegisteredKeyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
