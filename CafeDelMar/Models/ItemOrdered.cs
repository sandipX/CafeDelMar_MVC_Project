using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDelMar.Models
{
    public class ItemOrdered
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        
        private int _count;

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }
        private int _totalIncome;

        public int TotalIncome
        {
            get { return _totalIncome; }
            set { _totalIncome = value; }
        }
    }
}