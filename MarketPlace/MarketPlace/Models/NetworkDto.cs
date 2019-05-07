using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarketPlace.Models
{
    public class NetworkDto
    {
        public string id { get; set; }
        public string ipAddress { get; set; }
        public string type { get; set; }
        public int port { get; set; }
        public string clientId { get; set; }
        public string buildingId { get; set; }
        
        public List<DeviceDto> devices { get; set; }
    }
}
