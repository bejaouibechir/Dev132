using Doranco132.Console.DesignPattern.RepositoryPattern.Abstraction;
using Doranco132.Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.RepositoryPattern.ImplSqlServer
{
    public class DepartementRepository : IRepository<IDepartement, int>
    {
        public void Add(IDepartement entity)
        {
            ;
        }

        public void Delete(int id)
        {
            ;
        }

        public IDepartement Get(int id)
        {
            return null;
        }

        public IQueryable<IDepartement> Get()
        {
            return null;
        }

        public void Update(int id, IDepartement entity)
        {
            ;
        }
    }
}
