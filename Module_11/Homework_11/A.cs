using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    interface I1
    {
        void M();
    }

    interface I2
    {
        void M();
    }

    class A
    {
        public void M() { Console.WriteLine("A.M()"); } 
    }

    class B:A
    {

    }
}
