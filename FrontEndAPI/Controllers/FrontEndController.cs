using FrontEndApi.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FrontEndApi.Controllers
{
    [Authorize]
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
        [HttpGet, BasicAuthorization]
        public async Task<IActionResult> Get()
        {
            var response1 = await _httpClient.GetAsync(BackEnd1RequestUri);
            var response2 = await _httpClient.GetAsync(BackEnd2RequestUri);

            string content1 = string.Empty;
            if (response1.IsSuccessStatusCode)
            {
                content1 = await response1.Content.ReadAsStringAsync();
            }
            string content2 = string.Empty;

            if (response1.IsSuccessStatusCode)
            {
                content2 = await response2.Content.ReadAsStringAsync();
            }
                  

            return Ok(new { Backend1Result = content1, Backend2Result = content2 });
        }


        [HttpPost, BasicAuthorization]
        public async Task<IActionResult> Post([FromBody] string data)
        {
            var response1 = await _httpClient.PostAsync(BackEnd1RequestUri, new StringContent(data));
            var response2 = await _httpClient.PostAsync(BackEnd2RequestUri, new StringContent(data));

            string content1=string.Empty;
            if (response1.IsSuccessStatusCode)
            {
                content1 = await response1.Content.ReadAsStringAsync();
            }
            string content2= string.Empty;
            if (response1.IsSuccessStatusCode)
            {
                content2 = await response2.Content.ReadAsStringAsync();
            }

            return Ok(new { Backend1Result = content1, Backend2Result = content2 });
        }

       
    }
}
