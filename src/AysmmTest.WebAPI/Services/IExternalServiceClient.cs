using AysmmTest.WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AysmmTest.WebAPI.Services
{
    public interface IExternalServiceClient
    {
        Task<List<User>> GetUsersAsync();
    }
}
