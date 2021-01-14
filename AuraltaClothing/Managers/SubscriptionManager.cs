using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class SubscriptionManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public SubscriptionManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Add

        /// <summary>
        /// Add a Subscription to the Database
        /// </summary>
        /// <param name="name">Reference of the subscription's name</param>
        /// <param name="email">Reference of the subscription's email</param>
        /// <returns>True if the operation succeed, if not returns false.</returns>
        public bool AddSubscription(string name, string email)
        {
            try
            {
                Subscription subscription = new Subscription()
                {
                    // Name = name
                    Email = email
                };

                // Check if the email doesn't already exist
                if (!dbContext.Subscriptions.Any(s => s.Email.Equals(email)))
                {
                    dbContext.Subscriptions.Add(subscription);
                    dbContext.SaveChanges();
                }

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
        /// Get's a list of all subscriptions
        /// </summary>
        /// <returns>A list of all subscriptions</returns>
        public List<Subscription> GetAllSubscriptions()
        {

            try
            {
                return dbContext.Subscriptions.OrderByDescending(s => s.SubscriptionId).ToList();
            }
            catch (Exception)
            {
                return new List<Subscription>();
            }

        }

        #endregion

    }
}