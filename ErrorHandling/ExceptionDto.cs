using System;
using CarAppDotNetApi.Helpers;

namespace CarAppDotNetApi.ErrorHandling
{
    public class ExceptionDto
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }

        public ExceptionDto(int code, string message)
        {
            Code = code;
            Message = message;
            Timestamp = DateTime.Now.GetTimeStamp();
        }
    }
}