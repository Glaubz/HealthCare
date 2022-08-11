using Gigers.Domain.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gigers.GigersApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GigersController : ControllerBase
    {
        private readonly ILogger<GigersController> _logger;

        public GigersController(ILogger<GigersController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Gig> Get()
        {
            throw new NotImplementedException();
        }
    }
}
