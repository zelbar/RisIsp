using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RisIsp.CoreLib.Dto;
using System.ComponentModel.DataAnnotations;

namespace RisIsp.Bll.Models
{
    public class Address
    {
        public Address() { }

        public Address(CoreLib.Dto.Address address)
        {
            Id = address.Id;
            AreaCode = address.AreaCode;
            StreetName = address.StreetName;
            StreetNumber = address.StreetNumber;
        }

        public int Id { get; set; }

        [Required]
        [Display(Name = "Oznaka regije")]
        public string AreaCode { get; set; }

        [Required]
        [Display(Name = "Ulica")]
        public string StreetName { get; set; }

        [Required]
        [Display(Name = "Kućni broj")]
        public string StreetNumber { get; set; }

        public string FullAddress
        {
            get
            {
                return AreaCode + " - " + StreetName + ", " + StreetNumber;
            }
        }
    }
}
