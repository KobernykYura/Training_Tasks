using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class NoImplementedInterfaceException : Exception
    {
        public NoImplementedInterfaceException() : base()
        {

        }
        public NoImplementedInterfaceException(string message) : base(message)
        {

        }
        public NoImplementedInterfaceException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public NoImplementedInterfaceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
