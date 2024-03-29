﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RisIsp.Models
{
    public class Person
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

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
