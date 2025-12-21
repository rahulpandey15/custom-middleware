using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {

            var employee
                 = new
                 {
                     FirstName = "Rahul",
                     LastName = "Pandey"
                 };

            return Ok(employee);
        }
    }
}
