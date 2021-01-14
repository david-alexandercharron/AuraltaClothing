using AuraltaClothing.Enums;
using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using AuraltaClothing.Services;
using AuraltaClothing.ViewModels.Products;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{
    public class ProductController : Controller
    {

        #region Index

        public ActionResult Index(int id)
        {

            ProductVM viewModel = new ProductVM()
            {
                Product = new ProductManager().GetProductById(id),
                CurrencyCode = CookieService.GetCurrency(Request.Cookies)
            };
            
            return View(viewModel);
        }

        #endregion

        #region Add To Cart

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToCart(CartVM viewModel)
        {

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {
                // TODO: Check if product is not null (it exists)
                HttpContext.Response.SetCookie(CookieService.AddProductToCart(Request.Cookies, viewModel.ProductId, viewModel.Size, viewModel.Quantity));

                return RedirectToAction("Index", "ShoppingCart");
            }

            // If we are a user on the site use he database for the shopping cart
            Product product = new ProductManager().GetProductById(viewModel.ProductId);

            if(!new ShoppingCartManager().AddProductToCart(User.Identity.GetUserId(), 
                                                           product, viewModel.Size, 
                                                           viewModel.Quantity))
            {
                ModelState.AddModelError("", "An error has occured.");
            }


            if (!ModelState.IsValid)
            {
                return View();
            }

            return RedirectToAction("Index", "ShoppingCart");

        }

        #endregion


    }
}