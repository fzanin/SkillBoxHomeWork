namespace Homework_11_Math_Proxy_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IMath p = new MathProxy();

            Console.WriteLine("4 + 2 = " + p.Add(4, 2));
            Console.WriteLine("4 - 2 = " + p.Sub(4, 2));
            Console.WriteLine("4 * 2 = " + p.Mul(4, 2));
            Console.WriteLine("4 / 2 = " + p.Div(4, 2));

            Console.ReadLine();
        }
    }
}