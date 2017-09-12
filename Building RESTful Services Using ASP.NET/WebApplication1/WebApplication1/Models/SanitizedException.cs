using System;

namespace WebApplication1.Models
{
    public class SanitizedException
    {
        public SanitizedException InnerException { get; set; }

        public string Message { get; set; }

        public SanitizedException(Exception exception)
        {
            Message = exception.Message;

            if (exception.InnerException != null)
            {
                InnerException = new SanitizedException(exception.InnerException);
            }
        }
    }
}