

using Microsoft.AspNetCore.Mvc;

namespace aspApp1.controller
{
    internal class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
