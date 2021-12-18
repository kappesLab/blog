using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegatePredicate
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var words = new List<string> { "rain", "sun", "tiger", "tree", "hamburger", "cloud", "eagle", "ice-cream", "wood" };

            Console.Write("Lista: ");
            Console.WriteLine(String.Join(", ", words));

            Predicate<string> HasFourChars = (word) => word.Length == 4;
            Predicate<string> NegateHasFourChars = (word) => !HasFourChars(word);

            var not4 = words.FindAll(NegateHasFourChars);

            Console.Write("Le parole NON di quattro lettere sono: ");
            Console.WriteLine(string.Join(", ", not4));

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
