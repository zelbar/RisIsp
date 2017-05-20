using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Repositories;
using RisIsp.CoreLib.Dto;
using Dapper;

namespace RisIsp.Dal
{
    public class ServiceRepository : BaseRepository, IServiceRepository
    {
        public ServiceRepository(DbConnection db) : base(db)
        {

        }

        public Service Add(Service item)
        {
            throw new NotImplementedException();
        }

        public Service Edit(Service item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Service> FetchAll()
        {
            var rv = _db.Query<Service>("SELECT * FROM service ORDER BY category ASC;");
            return rv;
        }

        public Service FetchById(int id)
        {
            var rv = _db.QueryFirst<Service>("SELECT * FROM service WHERE id = @Id;",
                new { Id = id });
            return rv;
        }

        public Service Remove(int id)
        {
            throw new NotImplementedException();
        }
    }
}
