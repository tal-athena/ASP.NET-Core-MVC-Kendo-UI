using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTask.Models
{
    public class FeatureDto
    {
        public string id
        {
            get;
            set;
        }
        public string name { get; set; }
        public string icon { get; set; }
        public string url { get; set; }        
    }
}
