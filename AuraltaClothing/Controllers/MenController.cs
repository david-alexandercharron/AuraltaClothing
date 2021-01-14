using AuraltaClothing.Enums;
using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using AuraltaClothing.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{
    public class MenController : Controller
    {

        #region Index

        // GET: Men
        public ActionResult Index(ProductCategory category)
        {
            ProductsVM viewModel = new ProductsVM()
            {
                Category = category,
                Products = new ProductManager().GetProductByCategory(category, Gender.Male),
                CurrencyCode = Services.CookieService.GetCurrency(Request.Cookies)
            }; 

            viewModel.Products = viewModel.Products.Where(p => p.Category == category).ToList();

            return View(viewModel);
        }

        #endregion

        #region Category (Choose category : T-Shirts, Hoodies, Long Sleeves, Pocket T-Shirts)

        public ActionResult Category()
        {
            return View();
        }

        #endregion


    }
}