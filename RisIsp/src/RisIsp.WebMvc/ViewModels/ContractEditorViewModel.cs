using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.Bll.Models;

namespace RisIsp.WebMvc.ViewModels
{
    public class ContractEditorViewModel
    {
        public Contract Contract { get; set; }
        public IList<int> ContractIds { get; set; }
        public IEnumerable<int> AreaCodes { get; set; }
        public IEnumerable<string> StreetNames { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<ServicePackage> ServicePackages { get; set; }
    }
}
