using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnonymousPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int> { 1, -2, 3, 0, 7, -1, 5, 2 };

            Console.Write("Lista: ");
            Console.WriteLine(String.Join(", ", data));

            Predicate<int> IsPositive = delegate(int val) { return val > 0; };
            var filtered = data.FindAll(IsPositive);

            Console.Write("Lista filtrata: ");
            Console.WriteLine(string.Join(", ", filtered));

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
