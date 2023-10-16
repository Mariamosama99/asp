using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using ViewModel;

namespace aspApp1.controller
{
    public class AccountController : Controller
    {
        AccountManger AccManger;
        public AccountController(AccountManger accountManger)
        {
            AccManger = accountManger;
        }
        public IActionResult LogIn()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Regester()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Regest(UserSignUpViewModel RegesterView)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await AccManger.SignUp(RegesterView);
                if (result.Succeeded)
                {
                    return RedirectToAction("LogIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }
               
            }
              return View("LogIn");
        }

        [HttpGet]
        public IActionResult LogIn(string ReturnUrl = "/")
        {
            var Siginveiw = new UserSignInViewModel() { ReturnUrl = ReturnUrl };
            return View(Siginveiw);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(UserSignInViewModel UserLog)
        {
            if (ModelState.IsValid)
            {
                var result = await AccManger.SignIn(UserLog);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Invaild User Name Or Password");
                    return View();
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult SignOut()
        {
            AccManger.SignOut();
            return RedirectToAction("LogIn");
        }

    }

}


