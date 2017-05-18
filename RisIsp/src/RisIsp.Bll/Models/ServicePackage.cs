using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Bll.Models
{
    public class ServicePackage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal MonthlyCost { get; set; }
        
        public Service Service { get; set; }
    }
}
