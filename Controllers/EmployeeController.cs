using Microsoft.AspNetCore.Mvc;
using middleware.Models;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration configuration;

        public EmployeeController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {

            var response
                 = new
                 {
                     ProductApiKey = configuration.GetSection("ApiKeys:ProductApiKey").Value,
                     CustomerApiKey = configuration.GetSection("ApiKeys:CustomerApiKey").Value,
                 };

            return Ok(response);
        }
    }
}
