using ProyectoPrograWebHHK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProyectoPrograWebHHK.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Index()
        {
            var model = new ProductModel { ListaMotocicletas = new ProductModel().GetMotos() };
            return View(model);
        }

        public ActionResult Motorcycles()
        {
            return View();
        }

        public ActionResult MotorcycleParts()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ClientAccess()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ClientAccess(AccountModel model)
        {
            if (new AccountModel().LogIn(model) && ModelState.IsValid)
            {
                this.Session["LoggedClient"] = model;
                var cliente = (AccountModel)this.Session["LoggedClient"];
                FormsAuthentication.RedirectFromLoginPage(model.CorreoElectronico, true);

                return RedirectToAction("Cart");
            }
            else
            {
                TempData["CustomError"] = "Usuario o contraseña invalidos";
                return View();
            }
        }

        /// <summary>
        /// Cierra la sesión actual
        /// </summary>
        /// <returns>Regresa url para solicitar inicio de sesión nuevamente</returns>
        [HttpPost]
        public ActionResult LogOff()
        {
            this.Session["LoggedClient"] = null;
            return this.Json(new { result = "Redirect", url = Url.Action("Index", "Client") });
        }

        public ActionResult AddUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddUser(ClientModel model)
        {
            if (ModelState.IsValid)
            {
                if (new ClientModel().AddClient(model))
                {
                    return View("Index");
                }
                ModelState.AddModelError("Error","El correo ya existe");
                return View();
            }
            return View();
        }


        public ActionResult ServiceFindAgencies()
        {
            return View();
        }

        public ActionResult ServiceFindMechanical()
        {
            return View();
        }

        public ActionResult Cart()
        {
            var cliente = (AccountModel)this.Session["LoggedClient"];
            var idCliente = new ClientModel().GetIdClientByEmail(cliente);
            var model = new ShoppingCartModel { ShoppingCarts = new ShoppingCartModel().GetProductInCartByClient(idCliente) };

            return View(model);
        }
    }
}