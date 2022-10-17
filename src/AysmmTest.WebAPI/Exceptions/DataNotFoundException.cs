using System;
using AysmmTest.WebAPI.Exceptions.Base;

namespace AysmmTest.WebAPI.Exceptions
{
    public class DataNotFoundException : NotFoundException
    {
        public DataNotFoundException(string message) : base(message)
        {

        }

        public DataNotFoundException(string message, Exception ex) : base(message, ex)
        {

        }
    }
}
