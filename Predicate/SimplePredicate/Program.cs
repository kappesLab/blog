using System;
using System.Collections.Generic;



namespace SimplePredicate
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<int> { 1, -2, 3, 0, 7, -1, 5, 2 };

            Console.Write("Lista: ");
            Console.WriteLine(String.Join(", ", data));

            var predicate = new Predicate<int>(IsPositive);
            var filtered = data.FindAll(predicate);

            Console.Write("Lista filtrata: ");
            Console.WriteLine(string.Join(", ", filtered));

            // Press ENTER to exit
            Console.ReadLine();
        }

        static bool IsPositive(int val)
        {
            return val > 0;
        }
    }
}
