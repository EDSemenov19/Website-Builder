using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Website_Builder.Models;
using Website_Builder.Services.Websites.Services;

namespace Website_Builder.Controllers;

//[Route("Home/[action]")]
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
        // _websiteService.CreateWebsite(new Website { Name = "Test123", Code = "" });

        var websites = _websiteService.FetchAllWebsites();
        return View(websites);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/Home/WebsiteBuildView/{Id}")]
    public IActionResult WebsiteBuildView([FromRoute] string Id)
    {
        var website = _websiteService.FetchWebsite(Id);
        return View(website);
    }

    [Route("/Home/WebsiteView/{Id}")]
    public IActionResult WebsiteView([FromRoute] string Id)
    {
        var website = _websiteService.FetchWebsite(Id);
        return View(website);
    }

    public IActionResult WebsiteAddView()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

