using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AysmmTest.WebAPI.Exceptions.Base
{
    public class ExternalServiceException : ApplicationException
    {
        public ExternalServiceException(string message) : base(message)
        {

        }

        public ExternalServiceException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
