using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace TaskCancellationTokenException
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
            try
            {
                output.Wait();
                Console.WriteLine($"output.Status = {output.Status}");
            }
            catch (AggregateException aggEx)
            {
                foreach (var e in aggEx.InnerExceptions)
                {
                    // Handle the custom exception.
                    if (e is OperationCanceledException)
                    {
                        Console.WriteLine($"Task Cancellata: {e.Message}");
                    }
                }
                   
                Console.WriteLine($"output.Status = {output.Status}");
            }
            finally
            {
                tokenSource.Dispose();
            }
          

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

                token.ThrowIfCancellationRequested();
            }
        }


    }
}
