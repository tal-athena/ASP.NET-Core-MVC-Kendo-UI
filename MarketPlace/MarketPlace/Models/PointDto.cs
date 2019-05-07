using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Models
{
    public class PointDto
    {
        public string id { get; set; }
        public DeviceDto device { get; set; }
        public string description { get; set; }
        public string name { get; set; }
        public string objectType { get; set; }
        public string objectId { get; set; }
        public string assertId { get; set; }
        public bool archive { get; set; }
        public string lastUpdated { get; set; }
        public string addedBy { get; set; }
    }
}
