using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class MessageManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public MessageManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Add

        /// <summary>
        /// Add a message to the database
        /// </summary>
        /// <param name="message">Reference to a message object</param>
        /// <returns>True if the operation succeed, if not returns false.</returns>
        public bool AddMessage(Message message)
        {
            try
            {
                dbContext.Messages.Add(message);
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
        /// Get's a list of all messages
        /// </summary>
        /// <returns>A list of all messages</returns>
        public List<Message> GetAllMessages()
        {

            try
            {
                return dbContext.Messages.OrderByDescending(m => m.MessageId).ToList();
            }
            catch (Exception)
            {
                return new List<Message>();
            }

        }

        #endregion

    }
}