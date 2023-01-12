﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }


        public override string ToString()
        {
            return $"Id:{Id} Name:{Name} Region {Region}";
        }
    }

}
