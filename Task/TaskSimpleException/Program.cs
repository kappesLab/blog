using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace TaskSimpleException
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<string> output = Task.Factory.StartNew(DoReadAFile, "Pippo.txt");

            Console.WriteLine("Sono nel metodo chiamante PRIMA della lettura del risultato.");

            try
            {
                Console.WriteLine($"La task ha restituito: {output.Result}.");
            }
            catch (AggregateException aggEx)
            {
                Console.WriteLine("AggregateException intercettata durante l'attesa del task.");
                Console.WriteLine("Contenenente le seguenti eccezzioni:");
                foreach (var e in aggEx.InnerExceptions)
                {
                    Console.WriteLine($" - {e.Message}");
                }
            }

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static string  DoReadAFile(object arg)
        {
            var fileName = arg as string;
            string result = File.ReadAllText(fileName);
            return result;
        }

     

    }
}
