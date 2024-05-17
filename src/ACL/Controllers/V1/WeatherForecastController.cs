using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using ACL.Core.Models;
using ACL.Route;

namespace ACL.Controllers.V1
{
    /// <inheritdoc/>
    [Authorize]
    [ApiController]
   // [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        /// <inheritdoc/>
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        /// <inheritdoc/>
        [HttpGet] 
        [Authorize(Policy = "HasPermission")] 
        [Route(AclRoutesUrl.WeatherForecastRouteUrl.GetWeatherForecast, Name = AclRoutesName.AclWeatherForecastRouteNames.GetWeatherForecasts)]
        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
