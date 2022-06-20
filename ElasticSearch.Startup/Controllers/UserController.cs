using ElasticSearch.Client;
using ElasticSearch.Startup.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public partial class UserController : Controller
    {
        [HttpPost]
        public async Task<Person> CreateAsync([FromBody] CreateUserRequest request)
        {
            var person = new Person
            {
                Id = Guid.NewGuid().ToString(),
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address
            };
            Client client = new Client();

            await client.CreatAsync(person, HttpContext.RequestAborted);

            return person;

        }

        [HttpGet]
        public Task<Person> GetAsync(GetUserRequest request)
        {
            var instance = new Client();

            return instance.GetAsync(request.Id, HttpContext.RequestAborted);
        }
    }
}