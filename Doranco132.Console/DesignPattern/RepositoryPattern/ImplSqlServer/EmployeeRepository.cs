using Doranco132.Console.DesignPattern.RepositoryPattern.Abstraction;
using Doranco132.Console.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.RepositoryPattern.ImplSqlServer
{
    public class EmployeeRepository : IRepository<IEmployee, int>
    {
        public void Add(IEmployee entity)
        {
            ;
        }

        public void Delete(int id)
        {
            ;
        }

        public IEmployee Get(int id)
        {
            return null;
        }

        public IQueryable<IEmployee> Get()
        {
            return null;
        }

        public void Update(int id, IEmployee entity)
        {
            ;
        }
    }
}
