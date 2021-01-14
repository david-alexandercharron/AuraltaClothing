using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class PriceService
    {

        public static double GetPrice(Product product, string currency)
        {
            switch (currency)
            {
                case "CAD":
                    return product.Price;
                case "USD":
                    return product.PriceUSD;
                default:
                    return product.Price;
            }
        }

        public static double GetPrice(ShoppingCartProduct shoppingCartProduct, string currency)
        {
            switch (currency)
            {
                case "CAD":
                    return shoppingCartProduct.Product.Price;
                case "USD":
                    return shoppingCartProduct.Product.PriceUSD;
                default:
                    return shoppingCartProduct.Product.Price;
            }
        }

    }
}