using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class ShippingService
    {

        /// <summary>
        /// Get's the shipping type by a postal code
        /// </summary>
        /// <param name="postalCode">A reference of a postal code</param>
        /// <returns>The shipping type of the postal code</returns>
        public static ShippingType GetShippingTypeByPostalCode(string postalCode)
        {
            postalCode = postalCode.ToUpper().Replace(" ", "");
            Regex caRGX = new Regex(@"[ABCEGHJKLMNPRSTVXY][0-9][ABCEGHJKLMNPRSTVWXYZ] ?[0-9][ABCEGHJKLMNPRSTVWXYZ][0-9]");
            Regex usaRGX = new Regex(@"^\d{5}(?:[-\s]\d{4})?$");

            ShippingType shippingType;

            if (caRGX.IsMatch(postalCode))
            {
                shippingType = Enums.ShippingType.Canada;

            }
            else if (usaRGX.IsMatch(postalCode))
            {
                shippingType = Enums.ShippingType.USA;
            }
            else
            {
                shippingType = Enums.ShippingType.International;
            }

            return shippingType;
        }

    }
}