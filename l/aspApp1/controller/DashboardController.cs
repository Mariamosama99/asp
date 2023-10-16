using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Repository;

namespace aspApp1.controller
{
    public class DashboardController : Controller
    {
        ProductManager productManager;
        UnitOfWork unitOfWork;
        public DashboardController(ProductManager _productManager, UnitOfWork _unitOfWork)
        {
            productManager = _productManager;
            unitOfWork = _unitOfWork;
        }

        public IActionResult Index()
        {

            ViewData["Product"] = productManager.GetList().Select(i => i.Name).ToList();

            List<Product> list = productManager.Get().ToList();
            return View(list);
        }

    }
}
