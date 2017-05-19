using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.CoreLib.Dto
{
    public class ServicePackage
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal MonthlyPrice { get; set; }
        
        public int ServiceId { get; set; }
    }
}
