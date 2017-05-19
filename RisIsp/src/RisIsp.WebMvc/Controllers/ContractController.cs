using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RisIsp.Dal;
using RisIsp.Bll;
using RisIsp.Bll.Models;
using RisIsp.WebMvc.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RisIsp.WebMvc.Controllers
{
    public class ContractController : Controller
    {
        private readonly DbConnection _db;
        private readonly AddressServices _addressServices;
        private readonly ContractServices _contractServices;
        private readonly CustomerServices _customerServices;
        private readonly ServiceServices _serviceServices;

        public ContractController(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            _db = new DbConnection(connectionString);
            var addressRepository = new AddressRepository(_db);
            var contractRepository = new ContractRepository(_db);
            var customerRepository = new CustomerRepository(_db);
            var serviceRepository = new ServiceRepository(_db);
            var servicePackageRepository = new ServicePackageRepository(_db);

            _addressServices = new AddressServices(addressRepository);
            _contractServices = new ContractServices(addressRepository, 
                contractRepository, customerRepository, serviceRepository, 
                servicePackageRepository);
            _customerServices = new CustomerServices(customerRepository);
            _serviceServices = new ServiceServices(serviceRepository,
                servicePackageRepository);

        }

        // GET: /Contract/
        public IActionResult Index()
        {
            var model = new ContractIndexViewModel()
            {
                Contracts = _contractServices.GetAll()
            };

            return View(model);
        }

        // GET: /Contract/Edit/1
        public IActionResult Edit(int id)
        {
            var model = new ContractEditViewModel()
            {
                Addresses = _addressServices.GetAllAddresses(),
                AreaCodes = _addressServices.GetAreaCodes(),
                Customers = _customerServices.GetAll(),
                Contract = _contractServices.GetById(id),
                NumberOfContracts = _contractServices.GetNumberOfContracts(),
                Services = _serviceServices.GetAllServices(),
                ServicePackages = _serviceServices.GetAllServicePackages()
            };

            return View(model);
        }
    }
}
