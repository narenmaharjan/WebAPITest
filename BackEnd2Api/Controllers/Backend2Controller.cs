using Microsoft.AspNetCore.Mvc;

namespace BackEnd2Api.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class Backend2Controller : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.Delay(1500); // Artificial delay of 1.5 seconds
            return Ok("Backend2 Get operation completed.");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string data)
        {
            await Task.Delay(2500); // Artificial delay of 2.5 seconds
            return Ok($"Backend2 received data: {data}");
        }
    }
}
