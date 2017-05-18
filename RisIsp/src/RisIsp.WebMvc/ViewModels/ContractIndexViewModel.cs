using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.Bll.Models;

namespace RisIsp.WebMvc.ViewModels
{
    public class ContractIndexViewModel
    {
        public IEnumerable<Contract> Contracts { get; set; }
    }
}
