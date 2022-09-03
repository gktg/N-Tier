using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities.Models
{
    public class CountryInformation:BaseEntity
    {
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public string CountryISOCode { get; set; }
        public string CountryCurrency { get; set; }
    }
}
