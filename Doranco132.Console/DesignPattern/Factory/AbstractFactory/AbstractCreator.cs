using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.Factory.AbstractFactory
{
    abstract public class AbstractCreator
    {
        public abstract Handler FactoryMethod(ConnectionKind connectionKind);
    }
}
