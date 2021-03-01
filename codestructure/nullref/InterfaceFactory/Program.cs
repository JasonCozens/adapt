using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceFactory
{
    public interface ITest
    {
        int Increment();

        object TheObject();
    }
    class Program
    {
        static void Main(string[] args)
        {
            var iTest = InterfaceObjectFactory.New<ITest>();
            Console.WriteLine(iTest.GetType().FullName);
            Console.ReadLine();
        }
    }
}
