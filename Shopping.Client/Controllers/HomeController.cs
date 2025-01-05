using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Shopping.Client.Models;

namespace Shopping.Client.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HttpClient httpClient;

    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        httpClient = httpClientFactory.CreateClient("shoppingApiClient");
    }

    public async Task<IActionResult> Index()
    {

        var response = await httpClient.GetAsync("/api/Product");
        var content = await response.Content.ReadAsStringAsync();
        
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true // Allows case-insensitivity but preserves original capitalization
        };

        var productList = JsonSerializer.Deserialize<IEnumerable<Product>>(content, options);

        return View(productList);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
