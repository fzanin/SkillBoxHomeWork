using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_11_Math_Proxy_Example
{
    class MathProxy : IMath
    {
        Math math;

        public MathProxy()
        {
            math = null;
        }

        public double Add(double x, double y)
        {
            return x + y;
        }


        public double Sub(double x, double y)
        {
            return x - y;
        }

        public double Mul(double x, double y)
        {
            if (math == null)
                math = new Math();

            return math.Mul(x, y);
        }

        public double Div(double x, double y)
        {
            if (math == null)
                math = new Math();

            return math.Div(x, y);
        }

    }
}
