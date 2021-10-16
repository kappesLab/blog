using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousMethodDelegate
{
    class Program
    {
        // delegate type declaration
        public delegate void MyDelegate(int x);

        static void Main(string[] args)
        {
            int n = 100;
            int a = 100;

            Console.WriteLine($"Valori iniziali.");
            Console.WriteLine($"a = {a} - n = {n}");

            MyDelegate handler = delegate(int x)
            {
                n++;
                x++;
                Console.WriteLine($"Parametro locale(a->x) = {x} - Variabile esterna(n) = {n}");
            };
                                                                                                                                                                                                                                            
            handler(a);

            Console.WriteLine($"Valori finale.");
            Console.WriteLine($"a = {a} - n = {n}");

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
