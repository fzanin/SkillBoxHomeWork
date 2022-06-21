namespace Homework_11_Protection_Proxy_Example
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IClient client = new ProtectionProxy("thePassword");
            Console.WriteLine("main received: " + client.GetAccountNo());
            Console.WriteLine("main received: " + client.GetAccountNo());
            Console.Read();
        }
    }
}