using System;
using System.Collections.Generic;
using System.Text;

namespace UberApi
{

    [Serializable]
    public class UberApiException : Exception
    {
        private static readonly string BaseMenssage = "Exception in Uber Api";

        public UberApiException() { }
        public UberApiException(string message) : base(UberApiException.BaseMenssage +" - "+ message) { }
        public UberApiException(string message, Exception inner) : base(UberApiException.BaseMenssage + " - " + message, inner) { }

        protected UberApiException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
