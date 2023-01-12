using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.Factory.AbstractFactory
{
    public class ConcreteCreator : AbstractCreator
    {
        public override Handler FactoryMethod(ConnectionKind connectionKind)
        {
            try
            {
                switch (connectionKind)
                {
                    case ConnectionKind.PostgreSQL:
                        return new PostgreSQLHandler();
                    case ConnectionKind.SqlServer:
                        return new SqlServerHandler();
                    default:
                        throw new ArgumentException("Il faut choisir ou bien PostgreSQL" +
                            " ou Sql server oracle n'est pas encore disponible");
                }
            }
            catch (ArgumentException error)
            {
                Debug.WriteLine(error.Message);
                return null;
            }
        }
    }
}
