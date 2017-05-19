using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Bll.Models
{
    public class Service
    {
        public Service() { }

        public Service(CoreLib.Dto.Service service)
        {
            Id = service.Id;
            Category = service.Category;
            Description = service.Description;
        }

        public int Id { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Description { get; set; }
    }
}
