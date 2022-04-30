using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MvcApp1.Mssql;
using System.Security.Claims;

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
        [HttpPost]
        public IActionResult SignIn(Models.Request.UserSpecefication item)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,item.FirstName + " " + item.LastName)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            props.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddMinutes(5));
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}