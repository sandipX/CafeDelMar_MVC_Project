using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDelMar.Models
{
    public class FoodItems
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _price;

        public int Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private int _foodType;

        public int FoodType
        {
            get { return _foodType; }
            set { _foodType = value; }
        }
    }
}