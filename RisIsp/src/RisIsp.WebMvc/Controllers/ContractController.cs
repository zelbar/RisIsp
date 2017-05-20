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

        // GET: /Contract/Create
        [HttpGet]
        public IActionResult Create()
        {
            var model = getContractEditViewModel(null);
            return View(model);
        }

        // POST: /Contract/Create
        [HttpPost]
        public IActionResult Create(ContractEditorViewModel request, IEnumerable<int> servicePackageIds)
        {
            var contract = request.Contract;

            var sps = new List<ServicePackage>();
            foreach (var spid in servicePackageIds)
            {
                sps.Add(new ServicePackage() { Id = spid });
            }
            contract.ServicePackages = sps;

            var rv = _contractServices.Create(contract, servicePackageIds);
            return RedirectToAction("Edit", new { Id = rv.Id });
        }

        // GET: /Contract/Edit/1
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = getContractEditViewModel(id);
            return View(model);
        }

        // POST: /Contract/Edit/1
        [HttpPost]
        public IActionResult Edit(ContractEditorViewModel request, IEnumerable<int> servicePackageIds)
        {
            var contract = request.Contract;

            var sps = new List<ServicePackage>();
            foreach(var spid in servicePackageIds)
            {
                sps.Add(new ServicePackage() { Id = spid });
            }
            contract.ServicePackages = sps;

            _contractServices.Update(contract, servicePackageIds);
            var model = getContractEditViewModel(contract.Id);
            return View(model);
        }

        // GET: /Contract/Delete/1
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = getContractEditViewModel(id).Contract;
            return View(model);
        }

        // POST: /Contract/ConfirmDelete/1
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            _contractServices.Delete(id);
            return RedirectToAction("Index");
        }

        // GET: /Contract/ServicePackages
        public IActionResult ServicePackages()
        {
            return new JsonResult(_serviceServices.GetAllServicePackages());
        }

        private ContractEditorViewModel getContractEditViewModel(int? id)
        {
            Contract newContract = null;
            if (id.HasValue == false)
            {
                newContract = new Contract()
                {
                    ServicePackages = new List<ServicePackage>()
                };
            }
            return new ContractEditorViewModel()
            {
                StreetNames = _addressServices.GetStreetNames(),
                AreaCodes = _addressServices.GetAreaCodes(),
                Customers = _customerServices.GetAll(),
                Contract = id.HasValue ? _contractServices.GetById(id.Value) : newContract,
                ContractIds = _contractServices.GetContractIds().ToList(),
                Services = _serviceServices.GetAllServices(),
                ServicePackages = _serviceServices.GetAllServicePackages()
            };
        }

    }
}
