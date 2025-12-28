using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using middleware.Models;
using System.Runtime.CompilerServices;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private ApiKeyModelDto _apiKeysModelDto;

        public OptionController(IOptions<ApiKeyModelDto> options)
        {
            _apiKeysModelDto = options.Value;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var response
                 = new
                 {
                     CustomerApiKey = _apiKeysModelDto.CustomerApiKey,
                     ProductApiKey = _apiKeysModelDto.ProductApiKey,
                 };

            return Ok(response);

        }
    }
}
