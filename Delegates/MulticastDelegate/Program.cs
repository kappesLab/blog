using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MulticastDelegate
{
    class Program
    {
        // delegate type declaration
        public delegate void MyDelegate(string s);
        static void Main(string[] args)
        {
            MyDelegate handler = SayHello;
            handler += Tanks;

            handler("Davide");

            Console.WriteLine(" ----------------- ");

            handler -= Tanks;
            handler += Scold;

            handler("Marco");

            // Press ENTER to exit
            Console.ReadLine();
        }

        public static void SayHello(string name)
        {
            Console.WriteLine($"Ciao, {name}");
        }

        public static void Tanks(string name)
        {
            Console.WriteLine($"Grazie, {name}");
        }

        public static void Scold(string name)
        {
            Console.WriteLine($"Cosi non va bene, {name}!");
        }
    }
}
