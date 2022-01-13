using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmark.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenchmarkController : ControllerBase
    {
        [HttpGet]
        [Route("SyncOperation")]
        public IActionResult SyncOperation()
        {
            //We Are Simulating A Sync Process That Takees 2 seconds 
            Thread.Sleep(2000);
            return Ok();
        }


        [HttpGet]
        [Route("AsyncOperation")]
        public async Task<IActionResult> AsyncOperation()
        {
            //We Are Simulating An Async Process That Takees 2 seconds 
            await Task.Delay(2000);
            return Ok();
        }
    }
}
