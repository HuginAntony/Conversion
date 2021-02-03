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

        [HttpGet]
        [Route("temperature/celsius")]
        public async Task<IActionResult> ConvertToCelsius(decimal value)
        {
            return Ok();
        }

        [HttpGet]
        [Route("temperature/fahrenheit")]
        public async Task<IActionResult> ConvertToFahrenheit(decimal value)
        {
            return Ok();
        }

        [HttpGet]
        [Route("mass/kilograms")]
        public async Task<IActionResult> ConvertToKilograms(decimal value)
        {
            return Ok();
        }

        [HttpGet]
        [Route("mass/pounds")]
        public async Task<IActionResult> ConvertToPounds(decimal value)
        {
            return Ok();
        }

        [HttpGet]
        [Route("length/kilometers")]
        public async Task<IActionResult> ConvertToKilometers(decimal value)
        {
            return Ok();
        }

        [HttpGet]
        [Route("length/miles")]
        public async Task<IActionResult> ConvertToMiles(decimal value)
        {
            return Ok();
        }
    }
}
