using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class OrderManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public OrderManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Add

        public bool AddOrder(Order order, List<ProductOrder> productOrders)
        {
            try
            {
                dbContext.Orders.Add(order);
                dbContext.ProductOrders.AddRange(productOrders);
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

        /// <summary>
        /// Get's a list of all orders
        /// </summary>
        /// <returns>A list of all orders</returns>
        public List<Order> GetAllOrders()
        {

            try
            {
                return dbContext.Orders.OrderByDescending(o => o.OrderId).ToList();
            }
            catch (Exception)
            {
                return new List<Order>();
            }

        }

        #endregion

    }
}