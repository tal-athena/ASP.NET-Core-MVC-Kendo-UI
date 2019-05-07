using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTask.Models
{
    public class CreateProjectRequestDto
    {

        public string clientId
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

        public string postCode
        {
            get;
            set;
        }

        public string country
        {
            get;
            set;
        }

        public List<string> featureIds
        {
            get;
            set;
        }
    }
}
