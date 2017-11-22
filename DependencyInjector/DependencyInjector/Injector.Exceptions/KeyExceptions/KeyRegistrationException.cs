using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Injector.Exceptions
{
    [Serializable]
    public class KeyRegistrationException : Exception
    {
        public KeyRegistrationException() : base()
        {

        }
        public KeyRegistrationException(string message) : base(message)
        {

        }
        public KeyRegistrationException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public KeyRegistrationException(SerializationInfo info, StreamingContext context) : base(info, context)
        { 

        }

    }
}
