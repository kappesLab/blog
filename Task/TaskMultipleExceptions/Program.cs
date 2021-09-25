using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;



namespace TaskMultipleExceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = Task.Factory.StartNew(DoLongOperation1);
            Task task2 = Task.Factory.StartNew(DoLongOperation2);
            Task task3 = Task.Factory.StartNew(DoLongOperation3);

            Console.WriteLine("Sono nel metodo chiamante PRIMA della lettura del risultato.");

            try
            {
                Task.WaitAll(task1, task2, task3);
            }
            catch (AggregateException aggEx)
            {
                Console.WriteLine("AggregateException intercettata durante l'attesa dei tasks.");
                Console.WriteLine("Contenenente le seguenti eccezzioni:");
                foreach (var e in aggEx.InnerExceptions)
                {
                    Console.WriteLine($" - {e.Message}");
                }
            }

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoLongOperation1()
        {
            File.ReadAllText("Pippo.txt");
            Console.WriteLine("Io sono in DoLongOperation1");
        }


        private static void DoLongOperation2()
        {
            Thread.Sleep(1000);
            Console.WriteLine("Io sono in DoLongOperation2");
        }


        private static void DoLongOperation3()
        {
            Console.WriteLine("Io sono in DoLongOperation3");
            throw new CustomException("Questa eccezzione è generata in DoLongOperation3!"); ;
        }


        public class CustomException : Exception
        {
            public CustomException(String message) : base(message)
            { 
            }
        }
    }
}
