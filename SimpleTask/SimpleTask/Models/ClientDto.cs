using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTask.Models
{
    public class ClientDto
    {
        public string id
        {
            get;
            set;
        }

        public string logoUrl { get; set; }
        public List<ContactDto> contacts
        {
            get;
            set;
        }

        public List<FeatureDto> features
        {
            get;
            set;
        }

        public List<ProjectDto> projects
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
        public int type
        {
            get;
            set;
        }

        public int status
        {
            get;
            set;
        }
        
    }
}
