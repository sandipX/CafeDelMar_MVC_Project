using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CafeDelMar.Models;

namespace CafeDelMar.Controllers
{
    public class HomeController : Controller
    {

        //
        // GET: /Home/
        public ActionResult Menu()
        {
            List<FoodItems> menu = new List<FoodItems>();
            FoodItemsContext fc = new FoodItemsContext();
            menu = fc.GetAllItems();

            return View(menu);
        }
        public string Order(IEnumerable<FoodItems> fdList)
        {

            OrdersContext o1 = new OrdersContext();
            FoodOrdered f1 = new FoodOrdered();
            List<FoodOrdered> FLIst = new List<FoodOrdered>();
            o1.PlaceOrder(f1);
            return "Order Placed";
        }
        [HttpGet]
        public ActionResult Feedback()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Feedback(User u1)
        {
            return View("FeedbackSubmit");
        }
        public ActionResult GetAllOrders()
        {
            List<ItemOrdered> allorders = new List<ItemOrdered>();
            ItemOrderedContext ocn = new ItemOrderedContext();
            allorders = ocn.GetAllOrderDetail();
            return View(allorders);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}