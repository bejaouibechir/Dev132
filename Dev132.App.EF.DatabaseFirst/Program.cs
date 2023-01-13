using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev132.App.EF.DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FirmDBContext context = new FirmDBContext();
            var departments = context.Departments.ToList();
          
        }
    }
}

/*
 * Mise à jour ou l'ajout
  FirmDBContext context = new FirmDBContext();
            var dep = new Department { Id = 3, Name = "Marketing", Region = "Lile" };
            context.Departments.AddOrUpdate(dep);
            context.SaveChanges();//important d'appeler save changes
 
 */

/*
 FirmDBContext context = new FirmDBContext();
            var dep = context.Departments.SingleOrDefault(d => d.Id == 3);
            context.Departments.Remove(dep);
            context.SaveChanges();
 
 */

/*
 Code pour retourner une collection de données
  FirmDBContext context = new FirmDBContext();
            var departments = context.Departments.ToList();
 */