using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev132.EF.CodeFirst
{
    static public class Program
    {
        static public void Main(string[] args)
        {
            SchoolModel context = new SchoolModel();
            context.Students.Add(new Student { Id = 1, Name = "Bechir" });
            context.SaveChanges();
        }
    }
}
