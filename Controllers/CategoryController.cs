using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp1.Models;
namespace MvcApp1.Controllers
{
    public class CategoryController : Controller
    {
        ILogger<CategoryController> _logger;
        public CategoryController(ILogger<CategoryController> logger)
        {
            _logger = logger;            
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult CategoryNew()
        {
            return View();
        }
        public IActionResult CreateNewCategory()
        {
            return RedirectToAction("Category","Category");
        }
    }
}