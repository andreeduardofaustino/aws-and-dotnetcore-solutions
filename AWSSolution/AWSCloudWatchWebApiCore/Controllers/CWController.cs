using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;


namespace AWSCloudWatchWebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CWController : ControllerBase
    {
        private readonly ILogger<Controller> _logger;

        public CWController(ILogger<Controller> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult> LogTest()
        {
            _logger.LogInformation("This is an information log.");
            _logger.LogInformation("This is an warning log.");

            string criticalMessage = "This is a critical message";
            _logger.LogInformation("Critical Message: {0}", criticalMessage);

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error ocurred");
            }

            return Ok("All ok!");
        }
    }
}
