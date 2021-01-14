using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuraltaClothing.Paypal
{
    public class PaypalConfiguration
    {

        public readonly static string ClientId;
        public readonly static string ClientSecret;


        static PaypalConfiguration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        public static Dictionary<string, string> GetConfig()
        {
            // From the Paypal.Api
            return ConfigManager.Instance.GetProperties();
        }

        // Create access token
        private static string GetAccessToken()
        {
            return new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
        }

        // Return the APIContext object
        public static APIContext GetAPIContext()
        {
            var apiContext = new APIContext(GetAccessToken())
            {
                Config = GetConfig()
            };
            return apiContext;
        }




    }
}