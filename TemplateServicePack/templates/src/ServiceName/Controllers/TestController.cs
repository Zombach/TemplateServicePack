using Microsoft.AspNetCore.Mvc;
using ServiceName.Models.Hello;
using ServiceName.Services.Interfaces;

namespace ServiceName.Controllers;

public class TestController(ITestService testService) : BaseController
{
    [HttpPost]
    [Route("hello")]
    public async Task<ActionResult<HelloResponse>> Hello([FromBody] HelloRequest helloRequest, CancellationToken cancellationToken = default)
    {
        try
        {
            var response = await testService.Hello(helloRequest, cancellationToken);
            return Ok(response);
        }
        catch (Exception exception)
        {
            return BadRequest(exception.Message);
        }
    }
}
