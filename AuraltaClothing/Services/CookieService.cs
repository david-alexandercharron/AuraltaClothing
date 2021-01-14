using AuraltaClothing.Enums;
using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class CookieService
    {

        #region AddProductToCart

        /// <summary>
        /// Add a product to the guest cookie
        /// 
        /// The cookie template is id-size-quantity
        /// 
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <param name="id">The id of the new product to be added to the shopping cart</param>
        /// <param name="size">The size of the product to be added to the shopping cart</param>
        /// <param name="quantity">The quantity of this product to be added to the shopping cart</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie AddProductToCart(HttpCookieCollection cookies, int id, ProductSize size, int quantity)
        {
            // Get the Shoppin Cart Cookie
            HttpCookie shoppingCartCookie = cookies["shoppingCart"];

            string cookie = "";

            // If there is atleast one product in the Shopping Cart
            if (shoppingCartCookie != null && shoppingCartCookie.Value != "")
            {


                // If the product and size already exists, just change the quantity
                if(shoppingCartCookie.Value.Contains(id + "-" + size.ToString()))
                {
                    foreach (string item in shoppingCartCookie.Value.Split(','))
                    {
                        if(item.Contains(id + "-" + size.ToString()))
                        {
                            string q = item.Replace(id + "-" + size.ToString() + "-", "");

                            if (Int32.TryParse(q, out int x))
                            {
                                cookie = shoppingCartCookie.Value.Replace(item, id + "-" + size.ToString() + "-" + (x + quantity));
                            }
                        }
                    }
                    string test = shoppingCartCookie.Value.Split(',')[0].Replace(id + "-" + size.ToString(), "");
                }
                else
                {
                    // The product doesn't exist, so create it
                    cookie = shoppingCartCookie.Value + "," + cookie + id + "-" + size + "-" + quantity + ";";
                }


            }
            else
            {
                // This is the first product to be added to the cookie (cookie was empty)
                cookie = cookie + id + "-" + size + "-" + quantity + ";";
            }

            


            HttpCookie newCookie = new HttpCookie("shoppingCart", cookie)
            {
                Expires = DateTime.Now.AddMonths(6)
            };



            return newCookie;
        }

        #endregion

        #region GetProducts

        //public static List<Product> GetProducts(HttpCookie shoppingCartCookie)
        //{

        //    List<Product> products = new List<Product>();

        //    //HttpCookie shoppingCartCookie = cookies["shoppingCart"];

        //    if (shoppingCartCookie != null)
        //    {

        //        // [##-LG-##, ##-XS-##]
        //        string[] ids = shoppingCartCookie.Value.Split(',');

        //        ProductManager productManager = new ProductManager();
        //        foreach (string id in ids)
        //        {
        //            if (Int32.TryParse(id.Split('-')[0], out int x))
        //            {
        //                Product product = productManager.GetProductById(x);
        //                if (product != null)
        //                {
        //                    products.Add(product);
        //                }
        //            }
        //        }

        //    }

        //    return products;

        //}

        #endregion

        #region GetShoppingCartProducts

        /// <summary>
        /// Gets all the shopping cart products by the ids in the shoppingCart 
        /// cookie.
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <returns>List of products from the cookie. If there is no products in the list returned, this means there isn't any products in the cookie</returns>
        public static List<ShoppingCartProduct> GetShoppingCartProducts(HttpCookieCollection cookies)
        {

            List<ShoppingCartProduct> products = new List<ShoppingCartProduct>();

            HttpCookie shoppingCartCookie = cookies["shoppingCart"];

            if (shoppingCartCookie != null)
            {

                // [##-LG-##, ##-XS-##]
                string[] ids = shoppingCartCookie.Value.Split(',');

                ProductManager productManager = new ProductManager();
                foreach (string id in ids)
                {
                    if (Int32.TryParse(id.Split('-')[0], out int x))
                    {
                        Product product = productManager.GetProductById(x);
                        if (product != null)
                        {

                            ShoppingCartProduct scp = new ShoppingCartProduct()
                            {
                                Product = product,
                                Size = (ProductSize)Enum.Parse(typeof(ProductSize), id.Split('-')[1]),
                                Quantity = Int32.TryParse(id.Split('-')[2], out int q) ? q : 1
                            };

                            products.Add(scp);
                        }
                    }
                }

            }

            return products;
        }

        /// <summary>
        /// Overload function
        /// Gets all the shopping cart products by the ids in the shoppingCart 
        /// </summary>
        /// <param name="cookies">Reference to the cookie that contains the products</param>
        /// <returns>List of products from the cookie. If there is no products in the list returned, this means there isn't any products in the cookie</returns>
        public static List<ShoppingCartProduct> GetShoppingCartProducts(HttpCookie cookies)
        {

            List<ShoppingCartProduct> products = new List<ShoppingCartProduct>();

            HttpCookie shoppingCartCookie = cookies;

            if (shoppingCartCookie != null)
            {

                // [##-LG-##, ##-XS-##]
                string[] ids = shoppingCartCookie.Value.Split(',');

                ProductManager productManager = new ProductManager();
                foreach (string id in ids)
                {
                    if (Int32.TryParse(id.Split('-')[0], out int x))
                    {
                        Product product = productManager.GetProductById(x);
                        if (product != null)
                        {

                            ShoppingCartProduct scp = new ShoppingCartProduct()
                            {
                                Product = product,
                                Size = (ProductSize)Enum.Parse(typeof(ProductSize), id.Split('-')[1]),
                                Quantity = Int32.TryParse(id.Split('-')[2], out int q) ? q : 1
                            };

                            products.Add(scp);
                        }
                    }
                }

            }

            return products;
        }

        #endregion

        #region Edit (Increment, Decrement)

        /// <summary>
        /// Increment the quantity of products by 1 (Addition)
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <param name="productId">Reference of the product to be incremented</param>
        /// <param name="size">The size of the product to be incremented</param>
        /// <param name="quantity">The original quantity of the product</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie Increment(HttpCookieCollection cookies, int productId, ProductSize size, ref int quantity)
        {
            // addition
            HttpCookie shoppingCartCookie = cookies["shoppingCart"];
            string replace = productId + "-" + size + "-" + quantity;
            string newSCC = productId + "-" + size + "-" + ++quantity;
            string cart = shoppingCartCookie.Value.Replace(replace, newSCC);

            HttpCookie newCookie = new HttpCookie("shoppingCart", cart)
            {
                Expires = DateTime.Now.AddMonths(6)
            };

            return newCookie;
        }

        /// <summary>
        /// Decrement the quantity of products by 1 (Substraction)
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <param name="productId">Reference of the product to be decremented</param>
        /// <param name="size">The size of the product to be decremented</param>
        /// <param name="quantity">The original quantity of the product</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie Decrement(HttpCookieCollection cookies, int productId, ProductSize size, ref int quantity)
        {

            HttpCookie shoppingCartCookie = cookies["shoppingCart"];
            string replace = productId + "-" + size + "-" + quantity;

            string newSCC = productId + "-" + size + "-" + (quantity - 1 > 0 ? --quantity : 1);
            string cart = shoppingCartCookie.Value.Replace(replace, newSCC);

            HttpCookie newCookie = new HttpCookie("shoppingCart", cart)
            {
                Expires = DateTime.Now.AddMonths(6)
            };

            return newCookie;
        }

        #endregion

        #region RemoveProducts

        /// <summary>
        /// Remove all the products by the productId from the shoppingCart Cookie
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <param name="productId">The id of the product to be removed from the shopping cart</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie RemoveProducts(HttpCookieCollection cookies, int productId, ProductSize size, int quantity)
        {

            HttpCookie shoppingCartCookie = cookies["shoppingCart"];
            string remove = productId + "-" + size + "-" + quantity;
            string cart = shoppingCartCookie.Value.Replace("," + remove + ",", ",")
                                                  .Replace(remove + ",", "")
                                                  .Replace("," + remove, "")
                                                  .Replace(remove, "");

            HttpCookie newCookie = new HttpCookie("shoppingCart", cart)
            {
                Expires = DateTime.Now.AddMonths(6)
            };

            return newCookie;
        }

        #endregion

        #region ChangeCurrency

        /// <summary>
        /// Change the Currency
        /// </summary>
        /// <param name="currencyCode">The currency code that will be replaced.</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie ChangeCurrency(string currencyCode)
        {
            // Change Currency
            HttpCookie newCookie = new HttpCookie("currency", currencyCode)
            {
                Expires = DateTime.Now.AddMonths(6)
            };

            return newCookie;
        }

        #endregion

        #region GetCurrency

        /// <summary>
        /// Get's the current Currency
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <returns>The current currency code</returns>
        public static string GetCurrency(HttpCookieCollection cookies)
        {

            HttpCookie currency = cookies["currency"];
            
            if (currency != null && !currency.Value.Equals("") )
                return currency.Value;
            else
                return "CAD";
        }

        #endregion

        #region ChangeCountryCode

        /// <summary>
        /// Change the current CountryCode
        /// </summary>
        /// <param name="countryCode">The country code that will be replaced.</param>
        /// <returns>The new cookie to be replaced</returns>
        public static HttpCookie ChangeCountryCode(string countryCode)
        {
            // Change Currency
            HttpCookie newCookie = new HttpCookie("countryCode", countryCode)
            {
                Expires = DateTime.Now.AddMonths(6)
            };

            return newCookie;
        }

        #endregion

        #region GetCountryCode

        /// <summary>
        /// Get's the current Country Code
        /// </summary>
        /// <param name="cookies">HttpCookieCollection from the controller. Usually referenced as Request.Cookies</param>
        /// <returns>The current currency code</returns>
        public static string GetCountryCode(HttpCookieCollection cookies)
        {
            HttpCookie countryCode = cookies["countryCode"];

            if (countryCode != null && !countryCode.Value.Equals(""))
                return cookies["countryCode"].Value;
            else
                return "CA";
        }

        #endregion


    }
}