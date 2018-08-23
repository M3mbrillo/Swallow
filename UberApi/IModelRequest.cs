using System;
using System.Collections.Generic;
using System.Text;

namespace UberApi
{
    public interface IModelRequest
    {
        string Uri { get; }
    }

    public interface IModelRequestGet : IModelRequest
    {
        string ToUriParameters();
    }
}
