using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Repositories;
using RisIsp.CoreLib.Dto;
using Dapper;

namespace RisIsp.Dal
{
    public class ServicePackageRepository : BaseRepository, IServicePackageRepository
    {
        public ServicePackageRepository(DbConnection db) : base(db)
        {

        }

        public ServicePackage Add(ServicePackage item)
        {
            throw new NotImplementedException();
        }

        public ServicePackage Edit(ServicePackage item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ServicePackage> FetchAll()
        {
            var rv = _db.Query<ServicePackage>("SELECT * FROM servicepackage;");
            return rv;
        }

        public IEnumerable<ServicePackage> FetchByContractId(int id)
        {
            var rv = _db.Query<ServicePackage>("SELECT servicepackage.* FROM servicepackage JOIN contract_servicepackage ON servicepackage.id = contract_servicepackage.servicepackageid WHERE contractid = @Id", new { Id = id });
            return rv;
        }

        public ServicePackage FetchById(int id)
        {
            var rv = _db.QueryFirst<ServicePackage>("SELECT * FROM servicepackage WHERE id = @Id;",
                new { Id = id });
            return rv;
        }

        public ServicePackage Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
