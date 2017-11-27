using System;
using System.Runtime.Serialization;

namespace KSR.Common.Exceptions
{
    [Serializable]
    public class ConnectionException : Exception
    {
        public ConnectionException() : base()
        {

        }
        public ConnectionException(string message) : base(message)
        {

        }
        public ConnectionException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public ConnectionException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
