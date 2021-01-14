using AuraltaClothing.Enums;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class ProductManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public ProductManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets a Product by it's ProductId
        /// </summary>
        /// <param name="id">A reference of the ProductId</param>
        /// <returns>The product if it exists, if we return null</returns>
        public Product GetProductById(int id)
        {
            try
            {
                return dbContext.Products.Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        public List<Product> GetProductByCategory(ProductCategory category, Gender gender)
        {

            try
            {
                return dbContext.Products.Where(p => p.Category == category && (p.Gender == gender || p.Gender == Gender.Unisex)).ToList();
            }
            catch (Exception)
            {
                return null;
            }

        }

        public List<Product> GetProductsByShoppingCartId(int shoppingCartId)
        {
            try
            {
                List<ShoppingCartProduct> shoppingCartProducts = dbContext.ShoppingCartProducts.Include("Product")
                                                        .Where(scp => scp.ShoppingCartId == shoppingCartId).ToList();

                // Loop thru all the ShoppingCartProducts and add their product to return
                List<Product> products = new List<Product>();
                foreach (ShoppingCartProduct p in shoppingCartProducts)
                {
                    products.Add(p.Product);
                }

                return products;

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

    }
}