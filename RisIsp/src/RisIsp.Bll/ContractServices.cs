using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib;
using RisIsp.CoreLib.Dto;
using RisIsp.CoreLib.Repositories;
using RisIsp.Bll.Models;
using RisIsp.Dal;

namespace RisIsp.Bll
{
    public class ContractServices
    {
        private readonly IAddressRepository _addressRepository;
        private readonly IContractRepository _contractRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly IServicePackageRepository _servicePackageRepository;

        public ContractServices(
            AddressRepository addressRepository,
            ContractRepository contractRepository, 
            CustomerRepository customerRepository,
            ServiceRepository serviceRepository,
            ServicePackageRepository servicePackageRepository)
        {
            _addressRepository = addressRepository;
            _contractRepository = contractRepository;
            _customerRepository = customerRepository;
            _serviceRepository = serviceRepository;
            _servicePackageRepository = servicePackageRepository;
            
        }

        public int GetNumberOfContracts()
        {
            var cnt = _contractRepository.GetNumberOfContracts();
            return cnt;
        }

        public IEnumerable<Bll.Models.Contract> GetAll()
        {
            var contracts = _contractRepository.FetchAll();
            var rv = new List<Bll.Models.Contract>();

            foreach(var contract in contracts)
            {
                var address = _addressRepository.FetchById(contract.AddressId);
                var customer = _customerRepository.FetchById(contract.CustomerId);
                var bllContract = new Bll.Models.Contract(contract, address, customer);
                rv.Add(bllContract);
            }

            return rv;
        }

        public Bll.Models.Contract GetById(int id)
        {
            var dtoContract = _contractRepository.FetchById(id);
            var contract = new Bll.Models.Contract(dtoContract,
                _addressRepository.FetchById(dtoContract.AddressId),
                _customerRepository.FetchById(dtoContract.CustomerId)
                );
            return contract;
        }
    }
}
