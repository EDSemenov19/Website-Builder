using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Website_Builder.Models;
using Website_Builder.Services.Websites.Services;

namespace Website_Builder.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IWebsiteService _websiteService;

    public HomeController(ILogger<HomeController> logger, IWebsiteService websiteService)
    {
        _logger = logger;
        _websiteService = websiteService;
    }

    public IActionResult Index()
    {
        var websites = _websiteService.FetchAllWebsites();
        return View(websites);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult WebsiteBuildView()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

