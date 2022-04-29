using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MvcApp1.Mssql;

namespace MvcApp1.Controllers
{
    public class LoginController : Controller
    {
        ILogger<LoginController> _logger;
        private IExternalDataResolver _dataResolver { get; }

        public LoginController(ILogger<LoginController> logger, IExternalDataResolver dataResolver)
        {
            _logger = logger;
            _dataResolver = dataResolver;
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
