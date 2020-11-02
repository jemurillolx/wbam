using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace wbam.mypages.Models.Communication
{
    public class BamApiResponse<T> where T : class
    {
        public HttpStatusCode HttpResponseStatusCode { get; }
        public T Value { get; }
        public string Message { get; }

        public BamApiResponse(HttpStatusCode httpResponseStatusCode, T value)
        {
            HttpResponseStatusCode = httpResponseStatusCode;
            Value = value;
        }

        public BamApiResponse(HttpStatusCode httpResponseStatusCode, string message)
        {
            HttpResponseStatusCode = httpResponseStatusCode;
            Message = message;
        }
    }
}