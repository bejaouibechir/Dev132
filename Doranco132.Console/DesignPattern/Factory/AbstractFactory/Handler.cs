using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doranco132.Console.DesignPattern.Factory.AbstractFactory
{
    abstract public class Handler
    {
        abstract public void Get();
        abstract public void Read();
        abstract public void Update();
        abstract public void Delete();

    }
}
