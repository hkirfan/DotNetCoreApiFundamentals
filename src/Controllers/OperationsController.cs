using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CoreCodeCamp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationsController : ControllerBase
    {
        private readonly IConfiguration _config;

        public OperationsController(IConfiguration config)
        {
            _config = config;
        }

        [HttpOptions("reloadConfig")]
        public IActionResult ReloadConfig()
        {
            try
            {
                var root = (IConfigurationRoot) _config;
                root.Reload();
                return Ok();
            }
            catch
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}