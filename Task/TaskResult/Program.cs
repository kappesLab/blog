using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskResult
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> output = Task.Factory.StartNew(DoStuffWithReturn);

            Console.WriteLine("Sono nel metodo chiamante PRIMA della lettura del risultato.");
            Console.WriteLine($"La task ha restituito: {output.Result}.");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static int DoStuffWithReturn()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine("Io sono DoStuffWithReturn.");
            return 1001;
        }
    }
}
