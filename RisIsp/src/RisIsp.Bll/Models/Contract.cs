using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Dto;

namespace RisIsp.Bll.Models
{
    public class Contract
    {
        public Contract() { }

        public Contract(CoreLib.Dto.Contract contract, 
            CoreLib.Dto.Address address, CoreLib.Dto.Customer customer,
            IEnumerable<CoreLib.Dto.ServicePackage> servicePackages, 
            IEnumerable<CoreLib.Dto.Service> services)
        {
            Id = contract.Id;
            Address = new Address(address);
            Customer = new Customer(customer);
            SignDate = contract.SignDate;

            var spList = new List<Bll.Models.ServicePackage>();
            foreach(var sp in servicePackages)
            {
                spList.Add(new ServicePackage(sp, services.First(x => x.Id == sp.ServiceId)));
            }
            ServicePackages = spList;
        }

        public int Id { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public DateTime SignDate { get; set; }

        public IEnumerable<Bll.Models.ServicePackage> ServicePackages { get; set; }

        public decimal TotalMonthlyPrice
        {
            get
            {
                try
                {
                    return ServicePackages.Sum(x => x.MonthlyPrice);
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }
    }
}
