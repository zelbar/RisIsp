using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;
using Dapper;
using System.Data;
using RisIsp.CoreLib;

namespace RisIsp.Dal
{
    public class BaseRepository
    {
        protected readonly IDbConnection _db;

        public BaseRepository(DbConnection db)
        {
            _db = db.Connection;
        }
    }
}
