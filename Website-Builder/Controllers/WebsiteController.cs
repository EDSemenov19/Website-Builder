using Microsoft.AspNetCore.Mvc;
using Website_Builder.Services.Websites.Services;

namespace Website_Builder.Controllers;

public class WebsiteController : Controller
{
    private readonly ILogger<WebsiteController> _logger;
    private readonly IWebsiteService _websiteService;

    public WebsiteController(ILogger<WebsiteController> logger, IWebsiteService websiteService)
    {
        _logger = logger;
        _websiteService = websiteService;
    }

    [HttpPost]
    [Route("/Website/CreateWebsite")]
    public IActionResult CreateWebsite(string name)
    {
        var website = _websiteService.CreateWebsite(new Models.Website { Name = name, Code = "" });

        return RedirectToAction("WebsiteBuildView", "Home", new { Id = website.Id });
    }

    [HttpPost]
    [Route("/Website/UpdateWebsite")]
    public IActionResult UpdateWebsite(string id, string code)
    {
        var website = _websiteService.UpdateWebsite(id, code);

        return RedirectToAction("WebsiteBuildView", "Home", new { Id = id });
    }
}
