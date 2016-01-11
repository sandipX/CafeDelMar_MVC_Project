using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDelMar.Models
{
    public class FoodOrdered
    {
        private int _orderId;

        public int OrderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }
        private List<Orders> _foodItems;

        public List<Orders> FoodItems
        {
            get { return _foodItems; }
            set { _foodItems = value; }
        }
    }
}