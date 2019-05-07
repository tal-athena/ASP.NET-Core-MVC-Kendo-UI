using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTask.Models
{
    public class ProjectDto
    {
        public string id
        {
            get;
            set;
        }

        public ClientDto client
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }

        public string address1
        {
            get;
            set;
        }

        public string address2
        {
            get;
            set;
        }

        public string suburb
        {
            get;
            set;
        }

        public string postcode
        {
            get;
            set;
        }

        public string country
        {
            get;
            set;
        }

        public List<FeatureDto> features
        {
            get;
            set;
        }

        public List<TenantDto> tenants
        {
            get;
            set;
        }

        public List<ZoneDto> zones
        {
            get;
            set;
        }

        public List<FloorDto> floors
        {
            get;
            set;
        }
        
        public List<CategoryDto> categories
        {
            get;
            set;
        }

        public List<OpeningHoursDto> openingHours
        {
            get;
            set;
        }
    }
}
