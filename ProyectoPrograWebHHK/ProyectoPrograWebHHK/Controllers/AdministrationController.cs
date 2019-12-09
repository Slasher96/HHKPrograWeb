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
        public ActionResult Index(AccountModel model)
        {
            if (!new AccountModel().LogIn(model) && ModelState.IsValid)
            {
                ModelState.AddModelError("Usuario o contraseña invalidos", "Error al acceder");
            }

            return View();
        }
    }
}