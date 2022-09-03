using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project.Web.Models
{
    public class CountryVM
    {
        public string CountryName { get; set; }
        public string CountryCapital { get; set; }
        public string CountryISOCode { get; set; }
        public string CountryCurrency { get; set; }
    }
}