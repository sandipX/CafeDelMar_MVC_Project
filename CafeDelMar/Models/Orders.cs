using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDelMar.Models
{
    public class Orders
    {
      
        private int _foodId;

        public int FoodId
        {
            get { return _foodId; }
            set { _foodId = value; }
        }
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
    }
}