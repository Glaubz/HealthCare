using HealthCare.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.HealthCareApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthCareController : ControllerBase
    {
        private readonly ILogger<HealthCareController> _logger;

        public HealthCareController(ILogger<HealthCareController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Academia> Get()
        {
            throw new NotImplementedException();
        }
    }
}
