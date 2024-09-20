using System.Diagnostics;
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
        int duracionEnMilis = 2000; 
        SimularCargaDeCpu(duracionEnMilis);
        
        string respuesta = $"pong - Server IP: {_localIpAddress}";
        _logger.LogInformation(respuesta);
        return respuesta;
    }

    private void SimularCargaDeCpu(int duracionEnMilis)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        // Ejecuta un bucle mientras el tiempo de duración no haya terminado
        while (stopwatch.ElapsedMilliseconds < duracionEnMilis)
        {
            // Realiza cálculos intensivos para consumir CPU
            for (int i = 0; i < 1000000; i++)
            {
                double result = Math.Sqrt(i);
            }

        }

        stopwatch.Stop();
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