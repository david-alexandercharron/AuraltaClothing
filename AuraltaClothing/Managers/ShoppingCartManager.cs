using AuraltaClothing.Enums;
using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class ShoppingCartManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public ShoppingCartManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Create

        public ShoppingCart Create()
        {
            try
            {
                ShoppingCart shoppingCart = new ShoppingCart();
                dbContext.ShoppingCarts.Add(shoppingCart);
                dbContext.SaveChanges();
                return shoppingCart;
            }
            catch (Exception)
            {
                return null;
            }
        }

        #endregion

        #region Add

        /// <summary>
        /// Adds a product to the cart or updates the quantity if it already exists
        /// </summary>
        /// <param name="userId">Reference to the user id</param>
        /// <param name="product">Reference to the product to be added</param>
        /// <param name="size">Reference to the size of the product</param>
        /// <param name="quantity">Reference to the quantity of the products to be added</param>
        /// <returns>True if the operation succeed if not false</returns>
        public bool AddProductToCart(string userId, Product product, 
                                     ProductSize size, int quantity)
        {

            try
            {
                ApplicationUser user = dbContext.Users.Find(userId);

                // Get the ShoppingCartProduct specific to the product to be added (User.Cart, product and size)
                ShoppingCartProduct scp = dbContext.ShoppingCartProducts
                                          .SingleOrDefault(cart => cart.ShoppingCartId == user.ShoppingCartId 
                                          && cart.ProductId == product.ProductId && cart.Size == size);


                // If the scp is null, we create a new scp with the new productId, size and quantity
                if(scp == null)
                {
                    ShoppingCartProduct shoppingCartProduct = new ShoppingCartProduct
                    {
                        ProductId = product.ProductId,
                        ShoppingCartId = user.ShoppingCartId,
                        Size = size,
                        Quantity = quantity
                    };

                    dbContext.ShoppingCartProducts.Add(shoppingCartProduct);
                    
                }
                else
                {
                    scp.Quantity = scp.Quantity + quantity;
                }

                dbContext.SaveChanges();

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        #endregion

        #region Edit

        public int IncrementQuantity(string userId, int productId, ProductSize size)
        {
            try
            {
                ShoppingCart shoppingCart = GetShoppingCartByUser(userId);
                ShoppingCartProduct scp = dbContext.ShoppingCartProducts.Where(sc => sc.ShoppingCartId == shoppingCart.ShoppingCartId
                                                              && sc.ProductId == productId
                                                              && sc.Size == size).FirstOrDefault();
                scp.Quantity++;

                dbContext.SaveChanges();
                return scp.Quantity;
            }
            catch (Exception)
            {

                return 1;
            }
        }

        public int DecrementQuantity(string userId, int productId, ProductSize size)
        {
            try
            {
                ShoppingCart shoppingCart = GetShoppingCartByUser(userId);
                ShoppingCartProduct scp = dbContext.ShoppingCartProducts.Where(sc => sc.ShoppingCartId == shoppingCart.ShoppingCartId
                                                              && sc.ProductId == productId
                                                              && sc.Size == size).FirstOrDefault();
                scp.Quantity = (scp.Quantity - 1 > 0 ? --scp.Quantity : 1);

                dbContext.SaveChanges();
                return scp.Quantity;
            }
            catch (Exception)
            {

                return 1;
            }
        }

        #endregion

        #region Delete

        /// <summary>
        /// Remove all the selected products from the shopping cart of the current user
        /// </summary>
        /// <param name="userId">The id of the user</param>
        /// <param name="productId">The id of the product wished to be removed</param>
        /// <param name="size">The size of the product wished to be removed</param>
        /// <returns>True if the operation succeed if not false.</returns>
        public bool RemoveProductsFromCart(string userId, int productId, ProductSize size)
        {
            try
            {
                ShoppingCart shoppingCart = GetShoppingCartByUser(userId);
                // Remove the products with the corresponding ProductSize from the user cart
                dbContext.ShoppingCartProducts.RemoveRange(
                    dbContext.ShoppingCartProducts.Where(sc => sc.ShoppingCartId == shoppingCart.ShoppingCartId 
                                                              && sc.ProductId == productId 
                                                              && sc.Size == size).ToList());
                dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        #endregion

        #region Get

        public ShoppingCart GetShoppingCartByUser(string userId)
        {

            try
            {
                int shoppingCartId = dbContext.Users.Where(u => u.Id == userId).FirstOrDefault().ShoppingCartId;
                return dbContext.ShoppingCarts.Find(shoppingCartId);
            }
            catch (Exception)
            {
                return null;
            }

        }

        #endregion


    }
}