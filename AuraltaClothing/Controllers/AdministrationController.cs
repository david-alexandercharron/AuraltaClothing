using AuraltaClothing.Managers;
using AuraltaClothing.ViewModels.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{

    [Authorize(Roles = Roles.Admin)]
    public class AdministrationController : Controller
    {
        // GET: Administration
        public ActionResult Index()
        {
            AdministrationVM viewModel = new AdministrationVM();
            viewModel.Orders = new OrderManager().GetAllOrders();
            viewModel.Messages = new MessageManager().GetAllMessages();
            viewModel.Users = new UserManager().GetAllUsers();
            viewModel.Subscriptions = new SubscriptionManager().GetAllSubscriptions();

            return View(viewModel);
        }
    }

}