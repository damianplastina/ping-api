using Microsoft.AspNetCore.Mvc;

namespace PingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    private readonly ILogger<PingController> _logger;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "ping")]
    public String Get()
    {
        return "pong";
    }
}