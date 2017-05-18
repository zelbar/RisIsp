using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public Customer Customer { get; set; }

        public DateTime SignDate { get; set; }
    }
}
