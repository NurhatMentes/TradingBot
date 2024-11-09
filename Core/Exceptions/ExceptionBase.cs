using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions
{
    public abstract class ExceptionBase : Exception
    {
        public string Title { get; }
        public int StatusCode { get; }

        protected ExceptionBase(string message, string title, int statusCode)
            : base(message)
        {
            Title = title;
            StatusCode = statusCode;
        }
    }

}
