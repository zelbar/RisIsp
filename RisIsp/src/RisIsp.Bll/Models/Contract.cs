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
            CoreLib.Dto.Address address, CoreLib.Dto.Customer customer)
        {
            Id = contract.Id;
            Address = new Address(address);
            Customer = new Customer(customer);
            SignDate = contract.SignDate;
        }

        public int Id { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public DateTime SignDate { get; set; }
    }
}
