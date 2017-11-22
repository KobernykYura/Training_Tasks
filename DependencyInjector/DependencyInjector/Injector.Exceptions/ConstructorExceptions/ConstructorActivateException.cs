using System;
using System.Runtime.Serialization;

namespace Injector.Exceptions
{
    [Serializable]
    public class ConstructorActivateException : Exception
    {
        public ConstructorActivateException() : base()
        {

        }
        public ConstructorActivateException(string message) : base(message)
        {

        }
        public ConstructorActivateException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public ConstructorActivateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
