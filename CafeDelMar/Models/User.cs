using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CafeDelMar.Models
{
    public class User
    {
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        private string _feedback;

        public string Feedback
        {
            get { return _feedback; }
            set { _feedback = value; }
        }
        
    }
}