using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using middleware.Models;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<DepartmentResponseDto>> Get()
        {
            List<DepartmentResponseDto>
                 departmentList = [
                         new DepartmentResponseDto(1,"Inventory"),
                         new DepartmentResponseDto(2,"Supply Chain"),
                         new DepartmentResponseDto(3,"Delivery"),
                         new DepartmentResponseDto(4,"Human Resources"),
                     ];

            return Ok(departmentList);
        }
    }
}
