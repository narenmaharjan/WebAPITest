using Microsoft.AspNetCore.Mvc;

namespace BackEnd1API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Backend1Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(2000); // Artificial delay of 2 seconds
            return Ok("Backend1 Get operation completed.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string data)
        {
            await Task.Delay(3000); // Artificial delay of 3 seconds
            return Ok($"Backend1 received data: {data}");
        }
    }
}
