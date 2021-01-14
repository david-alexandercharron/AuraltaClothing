using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class ShoppingCartProductManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public ShoppingCartProductManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets a ShoppingCartProduct by it's ShoppingCartProductId
        /// </summary>
        /// <param name="id">A reference of the ShoppingCartProductId</param>
        /// <returns>The ShoppingCartProduct if it exists, if not we return null</returns>
        public ShoppingCartProduct GetShoppingCartProductById(int id)
        {
            try
            {
                return dbContext.ShoppingCartProducts.Find(id);
            }
            catch (Exception)
            {

                return null;
            }
        }

        /// <summary>
        /// Gets a ShoppingCartProduct with it's product with it by it's ShoppingCartId
        /// </summary>
        /// <param name="id">A reference of the ShoppingCartId</param>
        /// <returns>The ShoppingCartProduct if it exists, if not we return null</returns>
        public List<ShoppingCartProduct> GetShoppingCartProductByShoppingCartId(int id)
        {
            try
            {
                return dbContext.ShoppingCartProducts.Include("Product").Where(scp => scp.ShoppingCartId == id).ToList();
            }
            catch (Exception)
            {

                return new List<ShoppingCartProduct>();
            }
        }

        #endregion

    }
}