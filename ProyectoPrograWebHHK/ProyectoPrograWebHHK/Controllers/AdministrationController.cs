using ProyectoPrograWebHHK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoPrograWebHHK.Controllers
{
    public class AdministrationController : Controller
    {
        private const int DptoMotos = 1;
        private const int DptoRefacciones = 2;

        // GET: Administration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(AccountModel model)
        {
            if (!new AccountModel().LogInEmployee(model) && ModelState.IsValid)
            {
                TempData["CustomError"] = "Usuario o contraseña invalidos";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.CorreoElectronico, false);
                FormsAuthentication.RedirectFromLoginPage(model.CorreoElectronico, true);
                return RedirectToAction("Dashboard");
            }
        }

        public ActionResult Dashboard()
        {


            return View();
        }

        /// <summary>
        /// Cierra la sesión actual
        /// </summary>
        /// <returns>Regresa url para solicitar inicio de sesión nuevamente</returns>
        public ActionResult LogOff()
        {
            this.Session["LoggedClient"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Client");
        }

        public ActionResult Ventas()
        {
            this.Session["Vistas"] = "1";
            return RedirectToAction("Dashboard");
        }

        public ActionResult Productos()
        {
            this.Session["Vistas"] = "2";
            return RedirectToAction("Dashboard");
        }

        public ActionResult Clientes()
        {
            this.Session["Vistas"] = "0";
            return RedirectToAction("Dashboard");
        }

        [HttpPost]
        public ActionResult AddProduct(ProductModel model)
        {
            if (ModelState.IsValid && Request.Files.Count > 0)
            {
                string path = string.Empty;
                if (model.IdDepartamento == DptoRefacciones)
                {
                    path = Path.Combine(Server.MapPath("~/Resources/Images/Refacciones"), Path.GetFileName(model.ImageFile.FileName));
                }
                else if (model.IdDepartamento == DptoMotos)
                {
                    path = Path.Combine(Server.MapPath("~/Resources/Images/Motocicletas"), Path.GetFileName(model.ImageFile.FileName));
                }

                model.ImageFile.SaveAs(path);
                model.RutaImagen = Path.GetFileName(model.ImageFile.FileName);
                new ProductModel().AddProduct(model);
            }

            return View("Dashboard");
        }
    }
}