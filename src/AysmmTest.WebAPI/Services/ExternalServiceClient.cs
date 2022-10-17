using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using AysmmTest.WebAPI.Entities;

namespace AysmmTest.WebAPI.Services
{
    public class ExternalServiceClient : IExternalServiceClient
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ExternalServiceClient(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var url = _configuration["ExternalService:Url"];
            var responseString = await _httpClient.GetStringAsync(url);
            var users = JsonSerializer.Deserialize<List<User>>(responseString);

            return users;
        }
    }
}
