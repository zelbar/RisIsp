using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib;
using RisIsp.CoreLib.Dto;
using RisIsp.CoreLib.Repositories;
using System.Data;
using Dapper;

namespace RisIsp.Dal
{
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        public CustomerRepository(DbConnection db) : base(db)
        {

        }

        Customer IRepository<int, Customer>.Add(Customer item)
        {
            var rv = _db.QueryFirst<Customer>(
                "INSERT INTO customer(firstname, lastname, numberofid) VALUES(@FirstName, @LastName, @NumberOfId) RETURNING *;", 
                new { FirstName = item.FirstName, LastName = item.LastName, NumberOfId = item.NumberOfId });
            return rv;
        }

        Customer IRepository<int, Customer>.Edit(Customer item)
        {
            var rv = _db.QueryFirst<Customer>(
                "UPDATE customer SET firstname = @FirstName, lastname = @LastName, numberofid = @NumberOfId WHERE id = @Id RETURNING *;", 
                new { Id = item.Id, FirstName = item.FirstName, LastName = item.LastName, NumberOfId = item.NumberOfId });
            return rv;
        }

        IEnumerable<Customer> IRepository<int, Customer>.FetchAll()
        {
            var rv = _db.Query<Customer>("SELECT * FROM customer;");
            return rv;
        }

        Customer IRepository<int, Customer>.FetchById(int id)
        {
            var rv = _db.QueryFirst<Customer>("SELECT * FROM customer WHERE id = @Id;",
                new { Id = id });
            return rv;
        }

        Customer IRepository<int, Customer>.Remove(int id)
        {
            var rv = _db.QueryFirst<Customer>("DELETE FROM customer WHERE id = @Id RETURNING *;",
                new { Id = id });
            return rv;
        }
    }
}
