using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using middleware.Models;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionsMonitorController : ControllerBase
    {
        private IOptionsMonitor<ApiKeyModelDto> _apiKeysModelDto;

        public OptionsMonitorController(
            IOptionsMonitor<ApiKeyModelDto> options)
        {
            _apiKeysModelDto = options;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            ResponseModelDto responseModelDto
                 = new ResponseModelDto()
                 {
                     AppStartValues = new ApiKeyModelDto()
                     {
                         CustomerApiKey = _apiKeysModelDto.CurrentValue.CustomerApiKey,
                         ProductApiKey = _apiKeysModelDto.CurrentValue.ProductApiKey,
                     }
                 };
            string s = "Reading Updated Value.....";
            await Task.Delay(500);

            responseModelDto.AppUpdatedValues  = new ApiKeyModelDto()
            {
                CustomerApiKey = _apiKeysModelDto.CurrentValue.CustomerApiKey,
                ProductApiKey = _apiKeysModelDto.CurrentValue.ProductApiKey,
            };

            return Ok(responseModelDto);

        }
    }
}
