using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class TypeRegistrationException : Exception
    {
        public TypeRegistrationException() : base()
        {

        }
        public TypeRegistrationException(string message) : base(message)
        {

        }
        public TypeRegistrationException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public TypeRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
