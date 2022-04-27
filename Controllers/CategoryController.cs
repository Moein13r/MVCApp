using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MvcApp1.DataAccess;
using MvcApp1.Models;
using MvcApp1.Mssql;

namespace MvcApp1.Controllers
{
    public class CategoryController : Controller
    {
        ILogger<CategoryController> _logger;
        IExternalDataResolver _dataresolver;
        CategoryDAO DataAccess;
        public CategoryController(ILogger<CategoryController> logger,IExternalDataResolver dataresolver)
        {
            _logger = logger;            
            _dataresolver=dataresolver;
            DataAccess=new CategoryDAO(_dataresolver);
        }
        public IActionResult Category()
        {
            return View();
        }
        public IActionResult CategoryNew()
        {
            return View();
        }
        public IActionResult CreateNewCategory(MvcApp1.Models.Request.CategoryRequest item)
        {
            try
            {
                DataAccess.InsertCategory(item);
                return RedirectToAction("Category","Category");   
            }
            catch (Exception e)
            {
                return BadRequest("An Error Occured Durring The Save");
            }            
        }
    }
}