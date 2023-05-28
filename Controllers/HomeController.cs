using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using proyecto_M4_M5.Models;
using Newtonsoft.Json;

namespace proyecto_M4_M5.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
{

    const string apiUrl = "https://randomfox.ca/floof/";
    
    var client = new HttpClient();
    var response = client.GetAsync(apiUrl).Result;
    var content = response.Content.ReadAsStringAsync().Result;
    
    Zorras imatgeDeZorra = JsonConvert.DeserializeObject<Zorras>(content);
   

    return View(imatgeDeZorra);
}

    public IActionResult Privacy()
    {
        const string apiUrl = "https://random-d.uk/api/v1/random";
    
        var client = new HttpClient();
        var response = client.GetAsync(apiUrl).Result;
        var content = response.Content.ReadAsStringAsync().Result;
    
        Pato imagen_pato = JsonConvert.DeserializeObject<Pato>(content);

        return View(imagen_pato);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
