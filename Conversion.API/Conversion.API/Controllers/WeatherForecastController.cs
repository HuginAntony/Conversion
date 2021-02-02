using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conversion.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConversionController : ControllerBase
    {
        private readonly ILogger<ConversionController> _logger;

        public ConversionController(ILogger<ConversionController> logger)
        {
            _logger = logger;
        }
    }
}
