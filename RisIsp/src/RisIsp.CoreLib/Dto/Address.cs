using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.CoreLib.Dto
{
    public class Address
    {
        public int Id { get; set; }

        public string AreaCode { get; set; }

        public string StreetName { get; set; }

        public string StreetNumber { get; set; }
    }
}
