/**
* Sample code for the GetRates Canada Post service.
* 
* The GetRates service returns a list of shipping services, prices and transit times 
* for a given item to be shipped. 
*
* This sample is configured to access the Developer Program sandbox environment. 
* Use your development key username and password for the web service credentials.
* 
**/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Configuration;
using System.Security.Authentication;
using AuraltaClothing.Enums;

namespace CanadaPost
{
    class CanadaPostRates
    {
        //TLS 1.2 support for .NET 3.5
        private const SslProtocols _Tls12 = (SslProtocols)0x00000C00;
        private const SecurityProtocolType Tls12 = (SecurityProtocolType)_Tls12;

        public double GetRates(string postalCode, ShippingType shippingType)
        {
            ServicePointManager.SecurityProtocol = Tls12;

            var username = "username";//ConfigurationSettings.AppSettings["username"];
            var password = "password";//ConfigurationSettings.AppSettings["password"];
            var mailedBy = "0008948796";//ConfigurationSettings.AppSettings["customerNumber"];
            var url = "https://ct.soa-gw.canadapost.ca/rs/ship/price"; // REST URL
            var method = "POST"; // HTTP Method

            // Create mailingScenario object to contain xml request
            mailingscenario mailingScenario = new mailingscenario
            {
                parcelcharacteristics = new mailingscenarioParcelcharacteristics(),
                destination = new mailingscenarioDestination()
            };

            // remove dis shit
            string responseAsString = "";

            // Check Shipping Type 
            switch (shippingType)
            {
                case ShippingType.Canada:
                    mailingScenario.destination.Item = new mailingscenarioDestinationDomestic()
                    {
                        postalcode = postalCode
                    };
                    break;
                case ShippingType.USA:
                    mailingScenario.destination.Item = new mailingscenarioDestinationUnitedstates()
                    {
                        zipcode = postalCode
                    };
                    break;
                case ShippingType.International:
                    mailingScenario.destination.Item = new mailingscenarioDestinationInternational()
                    {
                        postalcode = postalCode
                    };
                    break;
                default:
                    break;
            }

            // Populate mailingScenario object
            mailingScenario.customernumber = mailedBy;
            mailingScenario.parcelcharacteristics.weight = 1;
            mailingScenario.parcelcharacteristics.dimensions = new mailingscenarioParcelcharacteristicsDimensions
            {
                length = 24,
                width = 4,
                height = 24
            };
            mailingScenario.originpostalcode = "postal code"; // Shipping Original Postal Code

            try
            {

                // Serialize mailingScenario object to String
                StringBuilder mailingScenarioSb = new StringBuilder();
                XmlWriter mailingScenarioXml = XmlWriter.Create(mailingScenarioSb);
                mailingScenarioXml.WriteProcessingInstruction("xml", "version=\"1.0\" encoding=\"UTF-8\"");
                XmlSerializer serializerRequest = new XmlSerializer(typeof(mailingscenario));
                serializerRequest.Serialize(mailingScenarioXml, mailingScenario);

                // Create REST Request
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;

                // Set Basic Authentication Header using username and password variables
                string auth = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes(username + ":" + password));
                request.Headers = new WebHeaderCollection();
                request.Headers.Add("Authorization", auth);

                // Write Post Data to Request
                UTF8Encoding encoding = new UTF8Encoding();
                byte[] buffer = encoding.GetBytes(mailingScenarioSb.ToString());
                request.ContentLength = buffer.Length;
                request.Headers.Add("Accept-Language", "en-CA");
                request.Accept = "application/vnd.cpc.ship.rate-v4+xml";
                request.ContentType = "application/vnd.cpc.ship.rate-v4+xml";
                Stream PostData = request.GetRequestStream();
                PostData.Write(buffer, 0, buffer.Length);
                PostData.Close();

                // Execute REST Request
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                // Deserialize response to pricequotes object
                XmlSerializer serializer = new XmlSerializer(typeof(pricequotes));
                TextReader reader = new StreamReader(response.GetResponseStream());
                pricequotes priceQuotes = (pricequotes)serializer.Deserialize(reader);

                return ((double) priceQuotes.pricequote.First().pricedetails.due);

                // Retrieve values from pricequotes object
                foreach (var priceQuote in priceQuotes.pricequote)
                {
                    responseAsString += "Service Name: " + priceQuote.servicename + "\r\n";
                    responseAsString += "Price Name: $" + priceQuote.pricedetails.due + "\r\n\r\n";
                }

            }
            catch (WebException webEx)
            {
                return 0; // 0 = error
                // TODO: Log these errors
                HttpWebResponse response = (HttpWebResponse)webEx.Response;

                if (response != null)
                {
                    responseAsString += "HTTP  Response Status: " + webEx.Message + "\r\n";

                    // Retrieve errors from messages object
                    try
                    {
                        // Deserialize xml response to messages object
                        XmlSerializer serializer = new XmlSerializer(typeof(messages));
                        TextReader reader = new StreamReader(response.GetResponseStream());
                        messages myMessages = (messages)serializer.Deserialize(reader);


                        if (myMessages.message != null)
                        {
                            foreach (var item in myMessages.message)
                            {
                                responseAsString += "Error Code: " + item.code + "\r\n";
                                responseAsString += "Error Msg: " + item.description + "\r\n";
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Misc Exception
                        responseAsString += "ERROR: " + ex.Message;
                    }
                }
                else
                {
                    // Invalid Request
                    responseAsString += "ERROR: " + webEx.Message;
                }

            }
            catch (Exception ex)
            {
                return 0; // 0 = error

                // Misc Exception
                responseAsString += "ERROR: " + ex.Message;
            }

            return 0; // TODO: should never get here, fix this
        }
    }
}
