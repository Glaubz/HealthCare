using HealthCare.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace Fit.HealthCareApi.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/")]
    public class HealthCareController : ControllerBase
    {
        private readonly ILogger<HealthCareController> _logger;

        public HealthCareController(ILogger<HealthCareController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("teste")]
        public IEnumerable<Academia> Get()
        {
            Console.WriteLine("Entrou no Get");
            throw new NotImplementedException();
        }


        [HttpGet, Route("teste")]
        public IEnumerable<Academia> Get2()
        {
            Console.WriteLine("Entrou no Get2");
            throw new NotImplementedException();
        }
    }
}
