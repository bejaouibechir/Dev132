using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.Model
{
    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Nom { get; set; }

        public decimal Salaire { get; set; }
    }
}
