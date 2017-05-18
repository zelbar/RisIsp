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

        Contract IRepository<int, Contract>.Add(Contract item)
        {
            var rv = _db.QueryFirst<Contract>(
                "INSERT INTO contract(addressid, signdate, customerid) VALUES(@AddressId, @SignDate, @CustomerId) RETURNING id, firstname, lastname;", 
                new { AddressId = item.AddressId, SignDate = item.SignDate, CustomerId = item.CustomerId });
            return rv;
        }

        Contract IRepository<int, Contract>.Edit(Contract item)
        {
            var rv = _db.QueryFirst<Contract>(
                "UPDATE person SET firstname = @FirstName AND lastname = @LastName WHERE id = @Id RETURNING id, firstname, lastname;",
                new { AddressId = item.AddressId, SignDate = item.SignDate, CustomerId = item.CustomerId });
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
            var rv = _db.QueryFirst<Contract>("DELETE FROM contract WHERE id = @Id RETURNING id, firstname, lastname;",
                new { Id = id });
            return rv;
        }
    }
}
