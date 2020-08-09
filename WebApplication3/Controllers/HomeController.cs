using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Main()
        {
            return View();
        }



        public ActionResult DrawChart()
        {
        
            var controller = DependencyResolver.Current.GetService<InventoryController>();
            controller.ControllerContext = new ControllerContext(this.Request.RequestContext,
            controller);

            return View("~/Views/Inventory/Index.cshtml",controller);
        }
        


    }
}