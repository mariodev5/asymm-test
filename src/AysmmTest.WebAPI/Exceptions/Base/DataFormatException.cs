using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AysmmTest.WebAPI.Exceptions.Base
{
    public class DataFormatException : ApplicationException
    {
        public DataFormatException(string message) : base(message)
        {

        }

        public DataFormatException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
