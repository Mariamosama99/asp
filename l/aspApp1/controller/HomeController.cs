using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Models;
using Repository;
using ViewModel;

namespace aspApp1.controller
{
    public class HomeController : Controller
    {
        ProductManager productManager;
        UnitOfWork unitOfWork;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Add(AddProductViewModel addProduct, UnitOfWork unitOfWork, productManager productManager)
        {
            if (ModelState.IsValid)
            {
                Product prd = new Product();
                prd.Name = addProduct.Name;
                prd.Price = addProduct.Price;
                prd.Quantity = addProduct.Quantity;
                prd.Description = addProduct.Description;
                prd.CategoryID = addProduct.CategoryID;
                productManager.Add(prd);
                unitOfWork.Commit();
                return RedirectToAction("Index");

            }
            else
            {
                return View();
            }
        }
        public IActionResult Edit (int Id)
        {
            Product product = new Product();
            return View();
        }


        //public IActionResult AboutUs()
        //{

        //    return RedirectToAction("Index");
        //}
        //public IActionResult ContactUs()
        //{
        //    return View("ContactUs");
        //}
    }
}

