using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository;
using ViewModel;

namespace aspApp1.controller
{
    public class RoleController : Controller
    {
        RoleManager RoleManager;
        public RoleController(RoleManager roleManager)
        {
            RoleManager = roleManager;
        }
        // GET: RoleController1
        public ActionResult AddAdmin()
        {
            ViewBag.Success = 0;
            ViewData["Data"] = RoleManager.GetList().Select(i => new AddRoleVeiwModel()
            {
                ID = i.Id,
                Name = i.Name
            }).ToList();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(AddRoleVeiwModel veiwModel)
        {

            if (ModelState.IsValid)
            {
                var result = await RoleManager.Add(veiwModel);
                if (result.Succeeded)
                {
                    ViewBag.Success = 1;
                }
                else
                {
                    ViewBag.Success = 2;
                }
            }
            else
            {
                ViewBag.Success = 2;
            }
            ViewData["Data"] = RoleManager.GetList().Select(i => new AddRoleVeiwModel()
            {
                ID = i.Id,
                Name = i.Name
            }).ToList();
            return View();

        }

    }
}
