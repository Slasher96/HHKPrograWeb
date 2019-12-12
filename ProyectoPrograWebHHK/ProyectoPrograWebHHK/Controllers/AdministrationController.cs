using ProyectoPrograWebHHK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProyectoPrograWebHHK.Controllers
{
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
            if (!new AccountModel().LogIn(model) && ModelState.IsValid)
            {
                ModelState.AddModelError("Usuario o contraseña invalidos", "Error al acceder");
            }

            return View();
        }

        [Authorize]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}