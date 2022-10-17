using System;

namespace AysmmTest.WebAPI.Exceptions.Base
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string message) : base(message)
        {

        }

        public NotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
