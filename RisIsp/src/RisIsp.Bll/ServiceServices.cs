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
    public class ServiceServices
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServicePackageRepository _servicePackageRepository;

        public ServiceServices(IServiceRepository serviceRepository, 
            IServicePackageRepository servicePackageRepository)
        {
            _serviceRepository = serviceRepository;
            _servicePackageRepository = servicePackageRepository;
        }

        public IEnumerable<Bll.Models.Service> GetAllServices()
        {
            var services = _serviceRepository.FetchAll();
            var rv = new List<Bll.Models.Service>();

            foreach(var service in services)
            {
                rv.Add(new Models.Service(service));
            }

            return rv;
        }

        public IEnumerable<Bll.Models.ServicePackage> GetAllServicePackages()
        {
            var servicePackages = _servicePackageRepository.FetchAll();
            var rv = new List<Bll.Models.ServicePackage>();

            foreach(var sp in servicePackages)
            {
                var service = _serviceRepository.FetchById(sp.ServiceId);
                var bllSp = new Bll.Models.ServicePackage(sp)
                {
                    Service = new Bll.Models.Service(service)
                };

                rv.Add(bllSp);
            }
            return rv;
        }
    }
}
