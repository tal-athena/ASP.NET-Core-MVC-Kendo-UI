using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Models
{
    public class DeviceDto
    {
        public string id { get; set; }
        public string deviceIdentifier { get; set; }
        public string ipAddress { get; set; }
        public string type { get; set; }
        public string clientId { get; set; }
        public string buildingId { get; set; }   
        public NetworkDto network { get; set; }

        public List<PointDto> points { get; set; }
    }
}
