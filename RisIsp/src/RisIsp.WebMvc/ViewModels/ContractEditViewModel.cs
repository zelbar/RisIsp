using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.Bll.Models;

namespace RisIsp.WebMvc.ViewModels
{
    public class ContractEditViewModel
    {
        public Contract Contract { get; set; }
        public int NumberOfContracts { get; set; }
        public IEnumerable<int> AreaCodes { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<ServicePackage> ServicePackages { get; set; }
    }
}
