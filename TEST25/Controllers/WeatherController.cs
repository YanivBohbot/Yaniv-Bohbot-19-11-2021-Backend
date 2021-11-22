using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TEST25.Models;
using TEST25.Services;

namespace TEST25.Controllers
{
    [ApiController]
    [Route("Weather")]
    public class WeatherController : ControllerBase
    {

        
        private readonly IWeatherService _weatherService;


        public WeatherController(IWeatherService weatherService)
        {

            _weatherService = weatherService;

        }


        [HttpGet]
        public string Get()
        {

            return "hello world";

        }

        // function to get the results of auto complete
        // with query params city_name
        // call the service with the params to call the api and return results
        [HttpGet]
        [Route("Search")]
        public async Task<string> GetAutoCompleteResults([FromQuery] string city_name)
        {

            return await _weatherService.GetResult(city_name);

        }


        // function to get the results of  the currentcondition of the city
        // with query params  key_city selected by users
        // call the service with the params to call the api and return results
        [HttpGet]
        [Route("GetCurrentWeather/{key_city}")]
        public async Task<string> GetCurrentCondition(string key_city)
        {

            return await _weatherService.GetCurrentWeather(key_city);

        }

    }
}
