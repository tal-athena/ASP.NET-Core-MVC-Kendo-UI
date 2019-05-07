using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTask.Models
{
    public class ContactDto
    {
        public string id
        {
            get;
            set;
        }
        public string name
        {
            get;
            set;
        }
        
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string suburb { get; set; }
        public string postcode { get; set; }
        public string country { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string position { get; set; }
        public string defaultContact { get; set; }

    }
}
