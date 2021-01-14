using AuraltaClothing.Managers;
using AuraltaClothing.Models;
using AuraltaClothing.Paypal;
using AuraltaClothing.Services;
using AuraltaClothing.ViewModels.Products;
using AuraltaClothing.ViewModels.ShoppingCart;
using Microsoft.AspNet.Identity;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{
    public class ShoppingCartController : Controller
    {

        #region Index

        #region Index

        // GET: ShoppingCart
        public ActionResult Index()
        {
            string currency = CookieService.GetCurrency(Request.Cookies);

            ShoppingCartVM viewModel = new ShoppingCartVM()
            {
                CurrencyCode = currency
            };

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {
                // Get products using the CookieService
                viewModel.Products = CookieService.GetShoppingCartProducts(Request.Cookies);

                viewModel.Subtotal = ShoppingCartService.GetSubTotal(viewModel.Products, currency);
                // Reverse the list so the most recent products are first
                viewModel.Products.Reverse();
                return View(viewModel);
            }

            ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

            viewModel.Products = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);


            viewModel.Subtotal = ShoppingCartService.GetSubTotal(viewModel.Products, currency);
            // Reverse the list so the most recent products are first
            viewModel.Products.Reverse();
            return View(viewModel);
        }

        #endregion

        #region DecrementProductQuantity

        [HttpPost]
        public ActionResult DecrementProductQuantity(CartVM viewModel)
        {

            List<ShoppingCartProduct> scps = new List<ShoppingCartProduct>();

            int qty = viewModel.Quantity; // this is to pass by reference to have the variable at return time

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {
                HttpCookie cookie = CookieService.Decrement(Request.Cookies, viewModel.ProductId,
                                                            viewModel.Size, ref qty);
                HttpContext.Response.SetCookie(cookie);

                scps = CookieService.GetShoppingCartProducts(cookie);
            }
            else // We are connected with a user account
            {
                ShoppingCartManager shoppingCartManager = new ShoppingCartManager();

                qty = shoppingCartManager.DecrementQuantity(User.Identity.GetUserId(), viewModel.ProductId, viewModel.Size);
                //TODO : Check error message and show it in view if error occured 


                ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

                scps = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);

            }

            return Json(new { price = ShoppingCartService.GetSubTotal(scps, CookieService.GetCurrency(Request.Cookies)), qty }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region IncrementProductQuantity

        [HttpPost]
        public ActionResult IncrementProductQuantity(CartVM viewModel)
        {

            List<ShoppingCartProduct> scps = new List<ShoppingCartProduct>();
            int qty = viewModel.Quantity; // this is to pass by reference to have the variable at return time

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {

                HttpCookie cookie = CookieService.Increment(Request.Cookies, viewModel.ProductId,
                                                            viewModel.Size, ref qty);
                HttpContext.Response.SetCookie(cookie);

                scps = CookieService.GetShoppingCartProducts(cookie);
            }
            else // We are connected with a user account
            {
                ShoppingCartManager shoppingCartManager = new ShoppingCartManager();

                qty = shoppingCartManager.IncrementQuantity(User.Identity.GetUserId(), viewModel.ProductId, viewModel.Size);
                //TODO : Check error message and show it in view if error occured 


                ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

                scps = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);

            }

            return Json(new { price = ShoppingCartService.GetSubTotal(scps, CookieService.GetCurrency(Request.Cookies)), qty }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region RemoveProduct

        [HttpPost]
        public ActionResult RemoveProduct(CartVM viewModel)
        {

            // TODO : Clean up, was tired
            List<ShoppingCartProduct> scps = new List<ShoppingCartProduct>();

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {

                HttpCookie cookie = CookieService.RemoveProducts(Request.Cookies, viewModel.ProductId,
                                                 viewModel.Size, viewModel.Quantity);

                HttpContext.Response.SetCookie(cookie);

                scps = CookieService.GetShoppingCartProducts(cookie);

            }
            else // We are connected with a user account
            {

                ShoppingCartManager shoppingCartManager = new ShoppingCartManager();

                if (shoppingCartManager.RemoveProductsFromCart(User.Identity.GetUserId(), viewModel.ProductId, viewModel.Size))
                {
                    //TODO : Check error message and show it in view if error occured 
                }


                ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

                scps = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);

            }

            if (scps.Count > 0)
            {
                return Json(new { price = ShoppingCartService.GetSubTotal(scps, CookieService.GetCurrency(Request.Cookies)) }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return PartialView("_EmptyShoppingCart");
            }

        }

        #endregion

        #endregion

        #region Checkout

        #region Checkout

        public ActionResult Checkout()
        {
            string currency = CookieService.GetCurrency(Request.Cookies);
            CheckoutVM viewModel = new CheckoutVM()
            {
                CurrencyCode = currency
            };

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {
                // Get products using the CookieService
                viewModel.Products = CookieService.GetShoppingCartProducts(Request.Cookies);

                viewModel.Subtotal = ShoppingCartService.GetSubTotal(viewModel.Products, currency);
                // Reverse the list so the most recent products are first
                viewModel.Products.Reverse();
                return View(viewModel);
            }

            ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

            viewModel.Products = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);


            viewModel.Subtotal = ShoppingCartService.GetSubTotal(viewModel.Products, currency);
            // Reverse the list so the most recent products are first
            viewModel.Products.Reverse();
            return View(viewModel);
        }

        #endregion

        #region CalculateShipping

        public ActionResult CalculateShipping(string postalCode)
        {
            postalCode = postalCode.ToUpper().Replace(" ", "");
            // Get the shipping type 
            Enums.ShippingType shippingType = ShippingService.GetShippingTypeByPostalCode(postalCode);


            // TODO : Rate the shipping depending on the products
            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {

            }
            else // We are connected with a user account
            {

            }

            CanadaPost.CanadaPostRates rates = new CanadaPost.CanadaPostRates();
            double price = rates.GetRates(postalCode, shippingType);

            return Json(new { price, error = price == 0 ? "The postal code must be valid" : null }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #endregion

        #region PaymentWithPaypal

        // Work with Paypal Payement
        private Payment payment;

        private Payment CreatePayment(APIContext apiContext, List<Product> products, ShippingAddress shippingAddress, string redirectUrl)
        {

            List<ShoppingCartProduct> shoppingCartProducts = new List<ShoppingCartProduct>();

            // If we are a guest on the site use cookies for the shopping cart
            if (!UserService.IsUserConnected(System.Web.HttpContext.Current.User))
            {
                // Get products using the CookieService
                shoppingCartProducts = CookieService.GetShoppingCartProducts(Request.Cookies);

                // Reverse the list so the most recent products are first
                shoppingCartProducts.Reverse();
            }
            else
            {
                ShoppingCart shoppingCart = new ShoppingCartManager().GetShoppingCartByUser(User.Identity.GetUserId());

                shoppingCartProducts = new ShoppingCartProductManager().GetShoppingCartProductByShoppingCartId(shoppingCart.ShoppingCartId);
            }



            //shippingAddress.country_code = "US";
            shippingAddress.country_code = "CA";
            string currency = CookieService.GetCurrency(Request.Cookies);
            //shippingAddress.country_code = CookieService.GetCountryCode(Request.Cookies);

            var items = new ItemList() { items = new List<Item>(),
                //shipping_address = new ShippingAddress()
                //{
                //    recipient_name = "john ros",
                //    line1 = "111 First Street",
                //    city = "Saratoga",
                //    state = "US",
                //    postal_code = "95070",
                //    country_code = "US",
                //    phone = "819 4443333"
                //}
                shipping_address = shippingAddress
            };

            foreach (ShoppingCartProduct scp in shoppingCartProducts)
            {
                items.items.Add(new Item()
                {
                    name = scp.Product.Name,
                    currency = currency,//"CAD",
                    //price = "0",
                    price = PriceService.GetPrice(scp, currency).ToString(),
                    quantity = scp.Quantity.ToString(),
                    sku = scp.Product.ProductId.ToString() + "S" + scp.Size,
                });
            }
            //items.items.FirstOrDefault().price = "0.60";

            // FOR TESTING 
            //items.items.Add(new Item()
            //{
            //    name = "Name-Test",
            //    currency = "CAD",
            //    price = 1.ToString(),
            //    quantity = 1.ToString(),
            //    sku = "sku",
            //});

            var payer = new Payer
            {
                payment_method = "paypal"
                
            };

            // Do the configuration RedirectURLs here with redirectURLs object
            RedirectUrls redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl,
                return_url = redirectUrl
            };


            // clean this 
            string postal_code = shippingAddress.postal_code.ToUpper().Replace(" ", "");
            double shipping = new CanadaPost.CanadaPostRates().GetRates(postal_code, ShippingService.GetShippingTypeByPostalCode(postal_code));
            //double shipping = 0;

            // Create details object
            Details details = new Details()
            {
                //tax = "0",
                shipping = shipping.ToString(),
                //shipping = "1",
                //subtotal = "0.60",
                subtotal = ShoppingCartService.GetSubTotal(shoppingCartProducts, currency).ToString(),
            };

            // Create amount object
            Amount amount = new Amount()
            {
                currency = currency,//"CAD",
                total = /*(Convert.ToDouble(details.tax) + */(Convert.ToDouble(details.shipping) + Convert.ToDouble(details.subtotal)).ToString(),
                details = details
            };

            // Create transaction
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction()
                {
                    description = "Auralta Clothing Order",
                    invoice_number = Convert.ToString((new Random()).Next(100000)),
                    amount = amount,
                    item_list = items
                }
            };

            // Create the web experience profile
            var profile = new WebProfile()
            {
                name = Guid.NewGuid().ToString(),
                presentation = new Presentation()
                {
                    brand_name = "Auralta Clothing",
                    locale_code = CookieService.GetCountryCode(Request.Cookies),//"CA",
                    //logo_image = "https://www.paypal.com/",
                    note_to_seller_label = "Thank you for doing business with Auralta Clothing",
                    return_url_label = "See you soon"
                  
                },

                input_fields = new InputFields()
                {
                    address_override = 1,
                    allow_note = true,
                    no_shipping = 1
                },
                
                
                temporary = true
            };

            var createdProfile = profile.Create(apiContext);
            
            payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = transactions,
                redirect_urls = redirUrls,

                // TODO: this id is permenant so hard code it
                experience_profile_id = createdProfile.id ,
                
            };

            return payment.Create(apiContext);

        }

        // private Payment ExecutePayment 
        private Payment ExecutePayment(APIContext apiContext, string payerId, string paymentId)
        {
            var paymentExecution = new PaymentExecution()
            {
                payer_id = payerId
            };

            payment = new Payment() { id = paymentId };
            return payment.Execute(apiContext, paymentExecution);

        }


        // Create PaymentWithPaypal method
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PaymentWithPaypal(ShippingAddress shippingAddress)
        {

            if (!ModelState.IsValid)
            {
                return View(shippingAddress);
            }

            // Getting context from the paypal bases on clientId and clientSecret for payment
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    // Creating a payment
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPaypal";
                    var guid = Convert.ToString((new Random()).Next(100000));

                    var createdPayment = CreatePayment(apiContext, new List<Product>() { new Product() }, shippingAddress, baseURI);


                    // Get links returned from paypal response to create call function
                    var links = createdPayment.links.GetEnumerator();
                    string paypaylRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypaylRedirectUrl = link.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypaylRedirectUrl);

                }
                else
                {

                    // This one will be executed when we have recieved all the payment params from previous call
                    var guid = Request.Params["paymentId"]; // Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, guid);//Session[guid] as string);
                    if(executedPayment.state.ToLower() != "approved")
                    {
                        return View("Index", "Errors");
                    }
                }



            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error : " + ex.Message);
                return View("Index", "Errors");
            }

            return View("PaymentSuccess");

        }

        // Create PaymentWithPaypal method
        public ActionResult PaymentWithPaypal()
        {

            // Getting context from the paypal bases on clientId and clientSecret for payment
            APIContext apiContext = PaypalConfiguration.GetAPIContext();

            try
            {
                string payerId = Request.Params["PayerID"];
                if (string.IsNullOrEmpty(payerId))
                {
                    // Creating a payment
                    string baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/ShoppingCart/PaymentWithPaypal";
                    var guid = Convert.ToString((new Random()).Next(100000));

                    var createdPayment = CreatePayment(apiContext, new List<Product>() { new Product() }, new ShippingAddress(), baseURI);


                    // Get links returned from paypal response to create call function
                    var links = createdPayment.links.GetEnumerator();
                    string paypaylRedirectUrl = string.Empty;

                    while (links.MoveNext())
                    {
                        Links link = links.Current;
                        if (link.rel.ToLower().Trim().Equals("approval_url"))
                        {
                            paypaylRedirectUrl = link.href;
                        }
                    }

                    Session.Add(guid, createdPayment.id);
                    return Redirect(paypaylRedirectUrl);

                }
                else
                {

                    // This one will be executed when we have recieved all the payment params from previous call
                    var guid = Request.Params["paymentId"]; // Request.Params["guid"];
                    var executedPayment = ExecutePayment(apiContext, payerId, guid);//Session[guid] as string);
                    if (executedPayment.state.ToLower() != "approved")
                    {
                        return View("Index", "Errors");
                    }

                    bool success = Save(executedPayment);
                    

                }



            }
            catch (Exception ex)
            {
                PaypalLogger.Log("Error : " + ex.Message);
                return View("Index", "Errors");
            }

            
            return View("PaymentSuccess");

        }

        #endregion

        private bool Save(Payment payment)
        {
            // Confusion between Paypal order and Model order
            Models.Order order = new Models.Order()
            {
                PayId = payment.id,
                ClientId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                Date = DateTime.Parse(payment.create_time),

                FirstName = payment.payer.payer_info.first_name,
                LastName = payment.payer.payer_info.last_name,
                Email = payment.payer.payer_info.email,
                PhoneNumber = payment.payer.payer_info.phone,

                City = payment.payer.payer_info.shipping_address.city,
                CountryCode = payment.payer.payer_info.shipping_address.country_code,
                AddressOne = payment.payer.payer_info.shipping_address.line1,
                PostalCode = payment.payer.payer_info.shipping_address.postal_code,
                State = payment.payer.payer_info.shipping_address.state,

                Currency = payment.transactions.FirstOrDefault().amount.currency,
                Total = payment.transactions.FirstOrDefault().amount.total,
            };


            List<ProductOrder> productOrders = new List<ProductOrder>();
            foreach (var item in payment.transactions.FirstOrDefault().item_list.items)
            {
                // TODO : Check if firstOrDefault doesnt return null before getting value

                string productId = item.sku.Split('S')[0];
                string size = item.sku.Split('S')[1];

                //string productId = item.supplementary_data.Where(sd => sd.name == "id").FirstOrDefault().value;
                //string size = item.supplementary_data.Where(sd => sd.name == "size").FirstOrDefault().value;

                productOrders.Add(new ProductOrder()
                {
                    Order = order,
                    ProductId = int.Parse(productId),
                    Quantity = int.Parse(item.quantity),
                    Size = StringToEnumService.ProductSizeToEnum(size)
                });
            }

            return new OrderManager().AddOrder(order, productOrders);
        }

    }
}