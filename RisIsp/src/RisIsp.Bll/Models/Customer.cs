using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Dto;

namespace RisIsp.Bll.Models
{
    public class Customer : Person
    {
        public Customer() { }

        public Customer(CoreLib.Dto.Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            NumberOfId = customer.NumberOfId;
        }
    }
}
