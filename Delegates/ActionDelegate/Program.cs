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
            Action handler = SayHello;
            handler();

            // Press ENTER to exit
            Console.ReadLine();
        }

        public static void SayHello()
        {
            Console.WriteLine($"Ciao");
        }

        public static void Tanks()
        {
            Console.WriteLine($"Grazie");
        }

    }
}
