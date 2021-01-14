using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class UserService
    {

        /// <summary>
        /// Checks if user is connected or authenticated
        /// </summary>
        /// <param name="user">Current user (System.Web.HttpContext.Current.User)</param>
        /// <returns>True if connected or authenticated and false if opposite</returns>
        public static bool IsUserConnected(IPrincipal user)
        {

            if ((user != null) && user.Identity.IsAuthenticated)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}