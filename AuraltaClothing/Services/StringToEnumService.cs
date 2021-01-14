using AuraltaClothing.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Services
{
    public static class StringToEnumService
    {

        /// <summary>
        /// Converts a string to a ProductSize enum
        /// </summary>
        /// <param name="size">Product size as a string</param>
        /// <returns>The corresponding ProductSize as a ProductSize</returns>
        public static ProductSize ProductSizeToEnum(string size)
        {
            switch (size)
            {
                case "XS":
                    return ProductSize.XS;
                case "S":
                    return ProductSize.S;
                case "M":
                    return ProductSize.M;
                case "L":
                    return ProductSize.L;
                case "XL":
                    return ProductSize.XL;
                case "XXL":
                    return ProductSize.XXL;
                default:
                    return ProductSize.L;
            }
        }

    }
}