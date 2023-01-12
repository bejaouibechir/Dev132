using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.Factory.AbstractFactory
{
    public class SqlServerHandler : Handler
    {
        public override void Delete()
        {
            Debug.WriteLine("Supprimer les données de la base Sql server");
        }

        public override void Get()
        {
            Debug.WriteLine("Avoir les données de la base Sql server");
        }

        public override void Read()
        {
            Debug.WriteLine("Lire les données de la base Sql server");
        }

        public override void Update()
        {
            Debug.WriteLine("Mettre à jour les données de la base Sql server");
        }
    }
}
