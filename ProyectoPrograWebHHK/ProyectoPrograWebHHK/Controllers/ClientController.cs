using ProyectoPrograWebHHK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
        public ActionResult ClientAccess(AccountModel model)
        {

            if (!new AccountModel().LogIn(model) && ModelState.IsValid)
            {
                ModelState.AddModelError("Usuario o contraseña invalidos", "Error al acceder");
            }

            return View();
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
                new ClientModel().AddClient(model);
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
            return View(new ShoppingCartModel {ShoppingCarts = new List<ShoppingCartModel>() });
        }

        [HttpPost]
        public ActionResult Cart(int idCliente)
        {
            var model = new ShoppingCartModel { ShoppingCarts = new ShoppingCartModel().GetProductInCartByClient(idCliente) };

            return View(model);
        }
    }
}