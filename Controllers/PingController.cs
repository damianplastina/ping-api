using System.Net;
using System.Net.Sockets;
using Microsoft.AspNetCore.Mvc;

namespace PingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    private readonly ILogger<PingController> _logger;
    private string _localIpAddress;

    public PingController(ILogger<PingController> logger)
    {
        _logger = logger;
        _localIpAddress = GetLocalIPAddress();
    }

    [HttpGet(Name = "ping")]
    public ActionResult<string> Get()
    {
        string respuesta = $"pong - Server IP: {_localIpAddress}";
        _logger.LogInformation(respuesta);
        return respuesta;
    }
    
    private string GetLocalIPAddress()
    {
        var host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (var ip in host.AddressList)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork)
            {
                return ip.ToString();
            }
        }
        throw new Exception("No network adapters with an IPv4 address in the system!");
    }
}