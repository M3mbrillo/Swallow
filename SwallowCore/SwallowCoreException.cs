using System;
using System.Collections.Generic;
using System.Text;

namespace SwallowCore
{

    [Serializable]
    public class SwallowCoreException : Exception
    {
        public SwallowCoreException() { }
        public SwallowCoreException(string message) : base("SwallowCore: " + message) { }
        public SwallowCoreException(string message, Exception inner) : base("SwallowCore: " + message, inner) { }
        protected SwallowCoreException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
