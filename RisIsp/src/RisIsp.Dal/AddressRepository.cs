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
    public class AddressRepository : BaseRepository, IAddressRepository
    {
        public AddressRepository(DbConnection db) : base(db)
        {

        }

        public IEnumerable<int> GetAreaCodes()
        {
            var rv = _db.Query<int>("SELECT DISTINCT areacode FROM address ORDER BY areacode ASC;");
            return rv;
        }

        public IEnumerable<string> GetStreetNames()
        {
            var rv = _db.Query<string>("SELECT DISTINCT streetname FROM address ORDER BY streetname ASC;");
            return rv;
        }

        Address IRepository<int, Address>.Add(Address item)
        {
            var rv = _db.QueryFirst<Address>(
                "INSERT INTO address(areacode, streetname, streetnumber) VALUES(@AreaCode, @StreetName, @StreetNumber) RETURNING *;",
                new { item.AreaCode, item.StreetName, item.StreetNumber });
            return rv;
        }

        Address IRepository<int, Address>.Edit(Address item)
        {
            var rv = _db.QueryFirst<Address>(
                "UPDATE address SET areacode = @AreaCode, streetname = @StreetName, streetnumber = @StreetNumber WHERE id = @Id RETURNING *;",
                new { item.AreaCode, item.StreetName, item.StreetNumber, Id = item.Id });
            return rv;
        }

        IEnumerable<Address> IRepository<int, Address>.FetchAll()
        {
            var rv = _db.Query<Address>("SELECT * FROM address;");
            return rv;
        }

        Address IRepository<int, Address>.FetchById(int id)
        {
            var rv = _db.QueryFirst<Address>("SELECT * FROM address WHERE id = @Id;",
                new { Id = id });
            return rv;
        }

        Address IRepository<int, Address>.Remove(int id)
        {
            var rv = _db.QueryFirst<Address>("DELETE FROM address WHERE id = @Id RETURNING *;",
                new { Id = id });
            return rv;
        }
    }
}
