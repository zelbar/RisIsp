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
    public class AddressServices
    {
        private readonly IAddressRepository _addressRepository;

        public AddressServices(IAddressRepository addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public IEnumerable<int> GetAreaCodes()
        {
            var rv = _addressRepository.GetAreaCodes();
            return rv;
        }

        public IEnumerable<Bll.Models.Address> GetAllAddresses()
        {
            var addresses = _addressRepository.FetchAll();
            var rv = new List<Bll.Models.Address>();

            foreach(var address in addresses)
            {
                rv.Add(new Models.Address(address));
            }

            return rv;
        }
    }
}
