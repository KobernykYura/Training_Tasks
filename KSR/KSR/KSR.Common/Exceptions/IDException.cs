using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Common.Exceptions
{
    /// <summary>
    /// Исключительная ситуация для нсуществующего в репозитории ID.
    /// </summary>
    [Serializable]
    public class IDException : Exception
    {
        public IDException() : base()
        {

        }
        public IDException(string message) : base(message)
        {

        }
        public IDException(string message, Exception innerException) : base(message, innerException)
        {

        }
        public IDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
