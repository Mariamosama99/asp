using Microsoft.AspNetCore.Mvc;


namespace aspApp1.controller
{
    internal class ProductController : Controller
    {
        public ViewResult Pending()
        {
            return View("Pending");
        }

    }
}
