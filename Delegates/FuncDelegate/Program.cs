using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuncDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string> handler1 = HelloWorld;
            Console.WriteLine(handler1());

            Func<string, string> handler2 = SayHello;
            Console.WriteLine(handler2("Davide"));

            // Anonymous method
            Func<string, string> handler3 = delegate(string s)
            {
                return $"Buona notte, {s}";
            };
            Console.WriteLine(handler3("Marco"));

            // Lambda expressions
            Func<string> handler4 = () => "Oggi c'è il sole.";
            Console.WriteLine(handler4());

            // Press ENTER to exit
            Console.ReadLine();
        }

        public static string HelloWorld()
        {
            return $"Ciao, mondo!";
        }

        public static string SayHello(string name)
        {
            return $"Ciao, {name}!";
        }
    }
}
