using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using middleware.Models;
using System.Runtime.CompilerServices;

namespace middleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionSnapshotController : ControllerBase
    {
        private IOptionsSnapshot<ApiKeyModelDto> _apiKeysModelDto;

        public OptionSnapshotController(IOptionsSnapshot<ApiKeyModelDto> options)
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
                        CustomerApiKey = _apiKeysModelDto.Value.CustomerApiKey,
                        ProductApiKey = _apiKeysModelDto.Value.ProductApiKey,
                    }
                };

            await Task.Delay(500);

            responseModelDto.AppUpdatedValues = new ApiKeyModelDto()
            {
                CustomerApiKey = _apiKeysModelDto.Value.CustomerApiKey,
                ProductApiKey = _apiKeysModelDto.Value.ProductApiKey,
            };

            return Ok(responseModelDto);

        }
    }
}
