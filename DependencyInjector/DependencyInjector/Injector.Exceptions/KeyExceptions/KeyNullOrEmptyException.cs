using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Injector.Exceptions
{
    [Serializable]
    public class KeyNullOrEmptyException : Exception
    {
        public KeyNullOrEmptyException() : base()
        {

        }
        public KeyNullOrEmptyException(string message) : base(message)
        {

        }
        public KeyNullOrEmptyException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public KeyNullOrEmptyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
