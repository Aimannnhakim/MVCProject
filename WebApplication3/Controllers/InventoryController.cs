using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace WebApplication3.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        public ActionResult Index()
        {
            int aexpired = AlreadyExpired();
            int nexpired = OtwExpired();

            string [] labels = { "Expired", "Not Expired" };
            int[] values = { AlreadyExpired(), OtwExpired()};

            ViewBag.lbl =labels;
            ViewBag.vlu = values;

            return View();
        }

        //create data object
        Models.Inventory item1 = new Models.Inventory { Id = 1, Exp = 0 };
        Models.Inventory item2 = new Models.Inventory { Id = 2, Exp = 10 };
        Models.Inventory item3 = new Models.Inventory { Id = 3, Exp = 5 };
        Models.Inventory item4 = new Models.Inventory { Id = 4, Exp = 0 };


        //insert object into list
        public List<Models.Inventory> ListItem()
        {

            List<Models.Inventory> Item = new List<Models.Inventory>();
            Item.Add(item1);
            Item.Add(item2);
            Item.Add(item3);
            Item.Add(item4);

            return Item;
        }

        //count expired tool
        public int AlreadyExpired() //Exp day = 0
        {
            var List = ListItem();
            var Expired = List.FindAll(item => item.Exp == 0);

            return Expired.Count;
        }

        //count non expired tool
        public int OtwExpired() //Exp day > 0
        {
            var List = ListItem();
            var Expired = List.FindAll(item => item.Exp > 0);

            return Expired.Count;
        }


    }

    
}