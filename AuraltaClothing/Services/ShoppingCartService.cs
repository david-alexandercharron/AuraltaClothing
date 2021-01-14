using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class ShoppingCartService
    {

        #region GetSubTotal

        /// <summary>
        /// Gets the subtotal of a list of products
        /// </summary>
        /// <param name="products">The list of products of which we want to calculate the subtotal</param>
        /// <returns>The subtotal as a double</returns>
        public static double GetSubTotal(List<Product> products, string currency)
        {
            double price = 0;

            foreach (Product p in products)
            {
                price += PriceService.GetPrice(p, currency);
            }

            return price;
        }

        /// <summary>
        /// Gets the subtotal of a list of products
        /// </summary>
        /// <param name="shoppingCartProducts">The list of products of which we want to calculate the subtotal</param>
        /// <returns>The subtotal as a double</returns>
        public static double GetSubTotal(List<ShoppingCartProduct> shoppingCartProducts, string currency)
        {
            double price = 0;

            foreach (ShoppingCartProduct scp in shoppingCartProducts)
            {
                price += PriceService.GetPrice(scp.Product, currency) * scp.Quantity;
            }

            return price;

        }

        #endregion

    }
}