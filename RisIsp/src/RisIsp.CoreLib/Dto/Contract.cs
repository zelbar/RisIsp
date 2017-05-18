using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.CoreLib.Dto
{
    public class Contract
    {
        public int Id { get; set; }

        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public DateTime SignDate { get; set; }
    }
}
