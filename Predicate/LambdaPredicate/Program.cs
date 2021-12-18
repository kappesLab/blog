using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string> { "rain", "sun", "tiger", "tree", "hamburger", "cloud", "eagle", "ice-cream", "wood" };

            Console.Write("Lista: ");
            Console.WriteLine(String.Join(", ", words));

            Predicate<string> HasFourChars = (word) => word.Length == 4;

            var word4 = words.FindAll(HasFourChars);

            Console.Write("Le parole di quattro lettere sono: ");
            Console.WriteLine(string.Join(", ", word4));

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
