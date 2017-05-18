using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Models
{
    public class ServicePackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MonthlyCost { get; set; }
        
        public Service Service { get; set; }
    }
}
