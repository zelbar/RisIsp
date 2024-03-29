﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib;
using RisIsp.CoreLib.Dto;

namespace RisIsp.CoreLib.Repositories
{
    public interface IContractRepository : IRepository<int, Contract>
    {
        int GetNumberOfContracts();
        IEnumerable<int> GetContractIds();

        void UpdateServicePackages(
            int contractId, IEnumerable<int> servicePackageIds);
    }
}
