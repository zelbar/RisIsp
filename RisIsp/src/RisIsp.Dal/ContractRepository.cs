using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using RisIsp.CoreLib;
using RisIsp.CoreLib.Dto;
using RisIsp.CoreLib.Repositories;
using Dapper;

namespace RisIsp.Dal
{
    public class ContractRepository : BaseRepository, IContractRepository
    {
        public ContractRepository(DbConnection db) : base(db)
        {

        }

        public int GetNumberOfContracts()
        {
            var cnt = _db.QuerySingle<int>("SELECT COUNT(*) FROM contract;");
            return cnt;
        }

        public IEnumerable<int> GetContractIds()
        {
            var rv = _db.Query<int>("SELECT id FROM contract ORDER BY id ASC;");
            return rv;
        }

        Contract IRepository<int, Contract>.Add(Contract item)
        {
            var rv = _db.QueryFirst<Contract>(
                "INSERT INTO contract(addressid, signdate, customerid) VALUES(@AddressId, @SignDate, @CustomerId) RETURNING *;", 
                new { AddressId = item.AddressId, SignDate = item.SignDate, CustomerId = item.CustomerId });
            return rv;
        }

        Contract IRepository<int, Contract>.Edit(Contract item)
        {
            var rv = _db.QueryFirst<Contract>(
                "UPDATE contract SET addressid = @AddressId, customerid = @CustomerId, signdate = @SignDate WHERE id = @Id RETURNING *;",
                new { AddressId = item.AddressId, SignDate = item.SignDate, CustomerId = item.CustomerId, Id = item.Id });
            return rv;
        }

        IEnumerable<Contract> IRepository<int, Contract>.FetchAll()
        {
            var rv = _db.Query<Contract>("SELECT * FROM contract;");
            return rv;
        }

        Contract IRepository<int, Contract>.FetchById(int id)
        {
            var rv = _db.QueryFirst<Contract>("SELECT * FROM contract WHERE id = @Id;",
                new { Id = id });
            return rv;
        }

        Contract IRepository<int, Contract>.Remove(int id)
        {
            var rv = _db.QueryFirst<Contract>("BEGIN WORK; DELETE FROM contract_servicepackage WHERE contractid = @Id; DELETE FROM contract WHERE id = @Id RETURNING *; COMMIT WORK;",
                new { Id = id });
            return rv;
        }

        public void UpdateServicePackages(int contractId,
            IEnumerable<int> servicePackageIds)
        {
            _db.Execute("DELETE FROM contract_servicepackage WHERE contractid = @Id;",
                new { Id = contractId });
            foreach(var id in servicePackageIds)
            {
                _db.Execute("INSERT INTO contract_servicepackage(servicepackageid, contractid) VALUES(@ServicePackageId, @ContractId);",
                    new { ServicePackageId = id, ContractId = contractId });
            }
        }
    }
}
