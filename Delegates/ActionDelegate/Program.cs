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
