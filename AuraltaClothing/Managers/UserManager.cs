using AuraltaClothing.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Managers
{
    public class UserManager
    {

        #region Attributes

        private AuraltaClothingDbContext dbContext;

        #endregion

        #region Constructor

        public UserManager()
        {
            dbContext = new AuraltaClothingDbContext();
        }

        #endregion

        #region Get

        /// <summary>
        /// Get's a list of all the users
        /// </summary>
        /// <returns>A list of all the users</returns>
        public List<ApplicationUser> GetAllUsers()
        {

            try
            {
                return dbContext.Users.ToList();
            }
            catch (Exception)
            {
                return new List<ApplicationUser>();
            }

        }

        #endregion

    }
}