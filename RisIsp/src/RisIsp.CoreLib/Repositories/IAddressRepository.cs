﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib;
using RisIsp.CoreLib.Dto;

namespace RisIsp.CoreLib.Repositories
{
    public interface IAddressRepository : IRepository<int, Address>
    {
        IEnumerable<int> GetAreaCodes();
        IEnumerable<string> GetStreetNames();
    }
}
