using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AysmmTest.WebAPI.Entities;
using AysmmTest.WebAPI.Services;
using AysmmTest.WebAPI.Filters;

namespace AysmmTest.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IExternalServiceClient _externalServiceClient;

        public UsersController(IExternalServiceClient externalServiceClient)
        {
            _externalServiceClient = externalServiceClient;
        }

        [HttpGet]
        [ServiceFilter(typeof(ActionFilterExample))]
        public async Task<ActionResult<List<User>>> Get()
        {
            var users = await _externalServiceClient.GetUsersAsync();

            return Ok(users);
        }
    }
}
