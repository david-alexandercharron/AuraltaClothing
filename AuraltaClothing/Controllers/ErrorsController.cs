using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuraltaClothing.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult Index()
        {
            return View("~/Views/Shared/Error.cshtml");
        }

    }
}