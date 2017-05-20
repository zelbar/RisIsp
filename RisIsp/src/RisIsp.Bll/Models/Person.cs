using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Bll.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Ime")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Prezime")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Broj osobne iskaznice")]
        [MaxLength(10)]
        [MinLength(10)]
        public string NumberOfId { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public string FormalFullName
        {
            get
            {
                return LastName + ", " + FirstName;
            }
        }
    }
}
