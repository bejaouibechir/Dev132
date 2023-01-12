using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.RepositoryPattern.Abstraction
{
   //Représente l'abstraction
    public interface IRepository<T,U>
    {
        void Add(T entity);
        void Update(U id, T entity);
        void Delete(U id);

        T Get(U id);
        IQueryable<T> Get();

    }
  
}
