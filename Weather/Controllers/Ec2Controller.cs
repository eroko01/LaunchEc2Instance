using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Dynamic;
using System.Diagnostics;
using System;
using System.IO;
using Ec2.ApplicationLayer;
using Ec2.InterfaceLayer.DTO;

namespace Ec2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
    public class Ec2Controller : ControllerBase
    {
        #region services
        private readonly ILogger<Ec2Controller> _logger;
        private readonly IService _service;
        #endregion

        public Ec2Controller(ILogger<Ec2Controller> logger, IService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost]
        [Route("ec2instance")]
        [Produces(typeof(RunInstanceResponse))]
        public async Task<ActionResult<RunInstanceResponse>> LaunchEc2Instance([FromBody] RunInstanceRequest runInstanceRequest)
        {
            _logger.LogInformation("POST method invoking EC2 instance launch");

            var body = await new StreamReader(Request.Body).ReadToEndAsync();

            var response = await _service.LaunchInstanceByRestCall(runInstanceRequest);
            return Ok(response);
        }
    }
}
