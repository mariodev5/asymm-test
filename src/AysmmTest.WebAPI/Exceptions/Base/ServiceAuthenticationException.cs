using System;

namespace AysmmTest.WebAPI.Exceptions.Base
{
    public class ServiceAuthenticationException : ApplicationException
    {
        public ServiceAuthenticationException(string message) : base(message)
        {

        }

        public ServiceAuthenticationException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
