using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp1.Models;
using MvcApp1.Mssql;

namespace MvcApp1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    IExternalDataResolver _dataResolver;

    public HomeController(ILogger<HomeController> logger, IExternalDataResolver dataResolver)
    {
        _logger = logger;
        _dataResolver = dataResolver;
    }

    public IActionResult Index()
    {
        return View();
        //return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
