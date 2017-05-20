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

        public IEnumerable<int> GetContractIds()
        {
            var rv = _contractRepository.GetContractIds();
            return rv;
        }

        public IEnumerable<Bll.Models.Contract> GetAll()
        {
            var contracts = _contractRepository.FetchAll();
            var rv = new List<Bll.Models.Contract>();

            foreach(var contract in contracts)
            {
                var address = _addressRepository.FetchById(contract.AddressId);
                var customer = _customerRepository.FetchById(contract.CustomerId);
                var servicePackages = _servicePackageRepository.FetchByContractId(contract.Id);
                var services = _serviceRepository.FetchAll();

                var bllContract = new Bll.Models.Contract(contract, address, customer, servicePackages, services);
                rv.Add(bllContract);
            }

            return rv;
        }

        public Bll.Models.Contract GetById(int id)
        {
            var dtoContract = _contractRepository.FetchById(id);
            var contract = new Bll.Models.Contract(dtoContract,
                _addressRepository.FetchById(dtoContract.AddressId),
                _customerRepository.FetchById(dtoContract.CustomerId),
                _servicePackageRepository.FetchByContractId(dtoContract.Id),
                _serviceRepository.FetchAll()
                );
            return contract;
        }

        public Bll.Models.Contract Create(Bll.Models.Contract contract,
            IEnumerable<int> servicePackageIds)
        {
            var dalAddress = new CoreLib.Dto.Address()
            {
                AreaCode = contract.Address.AreaCode,
                StreetName = contract.Address.StreetName,
                StreetNumber = contract.Address.StreetNumber
            };
            var addressId = _addressRepository.Add(dalAddress).Id;

            var dalCustomer = new CoreLib.Dto.Customer()
            {
                FirstName = contract.Customer.FirstName,
                LastName = contract.Customer.LastName,
                NumberOfId = contract.Customer.NumberOfId
            };
            var customerId = _customerRepository.Add(dalCustomer).Id;
            
            var dalContract = new CoreLib.Dto.Contract()
            {
                AddressId = addressId,
                CustomerId = customerId,
                SignDate = contract.SignDate
            };
            var rv = _contractRepository.Add(dalContract);

            _contractRepository.UpdateServicePackages(rv.Id, servicePackageIds);

            return new Models.Contract(rv, dalAddress, dalCustomer, 
                _servicePackageRepository.FetchByContractId(rv.Id), 
                _serviceRepository.FetchAll());
        }

        public Bll.Models.Contract Update(Bll.Models.Contract contract,
            IEnumerable<int> servicePackageIds)
        {
            var dalContract = new CoreLib.Dto.Contract()
            {
                Id = contract.Id,
                AddressId = contract.Address.Id,
                CustomerId = contract.Customer.Id,
                SignDate = contract.SignDate
            };
            _contractRepository.Edit(dalContract);

            var dalAddress = new CoreLib.Dto.Address()
            {
                Id = contract.Address.Id,
                AreaCode = contract.Address.AreaCode,
                StreetName = contract.Address.StreetName,
                StreetNumber = contract.Address.StreetNumber
            };
            _addressRepository.Edit(dalAddress);

            var dalCustomer = new CoreLib.Dto.Customer()
            {
                Id = contract.Customer.Id,
                FirstName = contract.Customer.FirstName,
                LastName = contract.Customer.LastName,
                NumberOfId = contract.Customer.NumberOfId
            };
            _customerRepository.Edit(dalCustomer);
            _contractRepository.UpdateServicePackages(contract.Id, servicePackageIds);

            return GetById(contract.Id);
        }

        public void Delete(int id)
        {
            _contractRepository.Remove(id);
        }
    }
}
