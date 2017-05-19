using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Dto;

namespace RisIsp.Bll.Models
{
    public class ServicePackage
    {
        public ServicePackage() { }

        public ServicePackage(CoreLib.Dto.ServicePackage servicePackage)
        {
            Id = servicePackage.Id;
            Name = servicePackage.Name;
            MonthlyPrice = servicePackage.MonthlyPrice;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal MonthlyPrice { get; set; }
        
        public Service Service { get; set; }

        public string NameAndMonthlyPrice
        {
            get
            {
                return Name + " (" + MonthlyPrice + ")";
            }
        }
    }
}
