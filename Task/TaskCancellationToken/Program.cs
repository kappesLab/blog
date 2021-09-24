using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskCancellationToken
{
    class Program
    {
        static void Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();

            // Pass the same token source to the delegate and to the task instance.
            Task output = Task.Run(() => DoStuff(tokenSource.Token), tokenSource.Token);

            Console.WriteLine("Premi un tasto per interrompere il task.");
            
            Console.ReadKey();
            tokenSource.Cancel();

            output.Wait();
            Console.WriteLine($"output.Status = {output.Status}");

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoStuff(CancellationToken token)
        {
            // Simulates a long-term operation
            while (true)
            {
                Console.WriteLine("Io sono il lavoro del task.");
                Thread.Sleep(500);

                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }

    }
}
