using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaDelegate
{
    class Program
    {
        // delegate type declaration
        public delegate bool PerformComparison(int x, string s);

        static void Main(string[] args)
        {
            PerformComparison handler = (int n, string t) => t.Length > n;
          
            Console.WriteLine($"{handler(6, "PIPPO")} = PerformComparison(6, 'PIPPO')");

            Console.WriteLine($"{handler(6, "PAPERINO")} = PerformComparison(6, 'PAPERINO')");

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
