using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Exercise.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly HttpClient _httpClient = new HttpClient();

        /// <summary>
        /// to count number of .Net substring accurance
        /// </summary>
        /// <returns>an integer showing number of .net accurance</returns>
        /// <response code="200">Returns count of accurance</response>
        /// <response code="400">If the item is null</response> 
        /// /// <remarks>
        /// Sample request:
        ///
        ///     POST /Todo
        ///     {
        ///        "id": 1,
        ///        "name": "Item1",
        ///        "isComplete": true
        ///     }
        ///
        /// </remarks>
        [HttpGet("DotNetCount")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<int> GetDotNetCount()
        {
            var html = await _httpClient.GetStringAsync("https://dotnetfoundation.org");

            return Regex.Matches(html, @".net").Count;
        }        
    }
}
