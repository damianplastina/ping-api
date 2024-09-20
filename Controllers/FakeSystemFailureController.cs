using Microsoft.AspNetCore.Mvc;

namespace PingApi.Controllers;

[ApiController]
[Route("")]
public class FakeSystemFailureController : ControllerBase
{
    private readonly ILogger<FakeSystemFailureController> _logger;
    private string _localIpAddress;

    public FakeSystemFailureController(ILogger<FakeSystemFailureController> logger)
    {
        _logger = logger;
    }

    [HttpGet("fail")]
    public ActionResult<string> Get()
    {
        Environment.FailFast("Simulated system failure.");
        return "hola";
    }
}