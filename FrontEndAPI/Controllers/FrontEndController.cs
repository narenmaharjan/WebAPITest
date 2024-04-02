using FrontEndApi.Filters;
using FrontEndApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrontEndApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FrontEndController : ControllerBase
    {
        private const string BackEnd1RequestUri = "http://localhost:5001/api/backend1";
        private const string BackEnd2RequestUri = "http://localhost:5002/api/backend2";
        private readonly IHttpClientRepository _httpClientRepository;

        public FrontEndController(IHttpClientRepository httpClientRepository)
        {
            _httpClientRepository = httpClientRepository ?? throw new ArgumentNullException(nameof(httpClientRepository));
        }

        
        [HttpGet, BasicAuthorization]
        public async Task<IActionResult> Get()
        {
            var response1 = await _httpClientRepository.GetAsync(BackEnd1RequestUri);
            var response2 = await _httpClientRepository.GetAsync(BackEnd2RequestUri);

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
            var response1 = await _httpClientRepository.PostAsync(BackEnd1RequestUri,data);
            var response2 = await _httpClientRepository.PostAsync(BackEnd1RequestUri,data);

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
