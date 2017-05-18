using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Dto;
using RisIsp.CoreLib.Repositories;
using RisIsp.Dal;
using RisIsp.Bll.Models;

namespace RisIsp.Bll
{
    public class CustomerServices
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerServices(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IEnumerable<Bll.Models.Customer> GetAll()
        {
            var customers = _customerRepository.FetchAll();
            var rv = new List<Bll.Models.Customer>();

            foreach(var customer in customers)
            {
                rv.Add(new Models.Customer(customer));
            }

            return rv;
        }
    }
}
