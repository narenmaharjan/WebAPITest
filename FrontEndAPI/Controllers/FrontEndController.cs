using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontEndApi.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndController : ControllerBase
    {
        private const string BackEnd1RequestUri = "http://localhost:5001/api/backend1";
        private const string BackEnd2RequestUri = "http://localhost:5002/api/backend2";
        private readonly HttpClient _httpClient;

        public FrontEndController(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // GET: api/<FrontEndController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result1 = await _httpClient.GetAsync(BackEnd1RequestUri);
            var result2 = await _httpClient.GetAsync(BackEnd2RequestUri);

            var content1 = await result1.Content.ReadAsStringAsync();
            var content2 = await result2.Content.ReadAsStringAsync();

            return Ok(new { Backend1Result = content1, Backend2Result = content2 });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string data)
        {
            var result1 = await _httpClient.PostAsync(BackEnd1RequestUri, new StringContent(data));
            var result2 = await _httpClient.PostAsync(BackEnd2RequestUri, new StringContent(data));

            var content1 = await result1.Content.ReadAsStringAsync();
            var content2 = await result2.Content.ReadAsStringAsync();

            return Ok(new { Backend1Result = content1, Backend2Result = content2 });
        }


    }
}
