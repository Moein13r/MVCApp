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
            if (HttpContext.Request.Cookies.ContainsKey("First_Request"))
            {
                HttpContext.Response.Cookies.Delete("First_Request");
                return RedirectToAction("Index", "Home");
            }
            HttpContext.Response.Cookies.Append("First_Request", "Moein", new CookieOptions { Expires = new DateTimeOffset(DateTime.Now.AddMinutes(2))}) ;
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(Models.Request.UserSpecefication item)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.UserData,"First_Request")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties();
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            return RedirectToAction("Index", "Home");
        }
    }
}