using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionDelegate
{
    class Program
    {
        static void Main(string[] args)
        {
            Action handler1 = SayHello;
            handler1();

            Action<string> handler2 = Tanks;
            handler2("Davide");

            // Anonymous method
            Action<string> handler3 = delegate(string s)
            {
                Console.WriteLine($"Buona notte, {s}");
            };
            handler3("Marco");

            // Lambda expressions
            Action handler4 = () => Console.WriteLine("Oggi c'è il sole.");
            handler4();

            // Press ENTER to exit
            Console.ReadLine();
        }

        public static void SayHello()
        {
            Console.WriteLine("Ciao");
        }

        public static void Tanks(string name)
        {
            Console.WriteLine($"Grazie, {name}");
        }

    }
}
