using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using AuraltaClothing.ViewModels.Home;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{
    public class HomeController : Controller
    {

        #region Index


        public ActionResult Index()
        {
            ProductManager productManager = new ProductManager();

            HomeVM homeVM = new HomeVM
            {
                Products = new List<Product>()
                {
                    productManager.GetProductById(348),
                    productManager.GetProductById(346),
                    productManager.GetProductById(357),
                    productManager.GetProductById(365)
                },

                CurrencyCode = Services.CookieService.GetCurrency(Request.Cookies)
            };

            return View(homeVM);
        }

        #endregion

        #region AddSubscriber (AJAX)

        [HttpPost]
        public ActionResult AddSubscriber(string name, string email)
        {

            List<ShoppingCartProduct> scps = new List<ShoppingCartProduct>();

            bool success = new SubscriptionManager().AddSubscription(name, email);

            return Json(new { success }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region About

        public ActionResult About()
        {
            return View();
        }

        #endregion

        #region Contact

        public ActionResult Contact()
        {
            return View();
        }

        #endregion

        #region Contact (POST)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(MessageVM viewModel)
        {

            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            // Create a Message object
            Message message = new Message()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                Email = viewModel.Email,
                Subject = viewModel.Subject,
                Description = viewModel.Description,
            };

            // Add the message to the database
            if (!new Managers.MessageManager().AddMessage(message))
            {
                ModelState.AddModelError("", "An error has occured.");
                return View(viewModel);
            }

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region ChangeCurrency

        [HttpPost]
        public ActionResult ChangeCurrency(string currencyCode, string countryCode)
        {
            HttpCookie cookie = Services.CookieService.ChangeCurrency(currencyCode);
            HttpContext.Response.SetCookie(cookie);

            cookie = Services.CookieService.ChangeCountryCode(countryCode);
            HttpContext.Response.SetCookie(cookie);

            return Json(new { currencyCode, countryCode }, JsonRequestBehavior.AllowGet);
        }

        #endregion

    }
}