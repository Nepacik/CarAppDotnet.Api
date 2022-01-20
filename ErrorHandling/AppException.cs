using System;
using System.Globalization;
using System.Net;

namespace CarAppDotNetApi.ErrorHandling
{
    public class AppException : Exception
    {

        public HttpStatusCode HttpStatusCode { get; set; }
        public AppException() : base("Internal server error")
        {
            HttpStatusCode = HttpStatusCode.InternalServerError;
        }
        public AppException(HttpStatusCode httpStatusCode, string message) : base(message)
        {
            HttpStatusCode = httpStatusCode;
        }
        public AppException(HttpStatusCode httpStatusCode) : base("")
        {
            HttpStatusCode = httpStatusCode;
        }

    }
}