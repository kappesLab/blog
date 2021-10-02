using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskContinueWith
{
    class Program
    {
        static void Main(string[] args)
        {
            Task one = Task.Factory.StartNew(DoLongOperation1);
            Task two = one.ContinueWith(DoLongOperation2);
            two.Wait();

            Console.WriteLine($"two.Status = {two.Status}");

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoLongOperation1()
        {
            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine($"Iso sono al termine di DoLongOperation(1)");
        }

        private static void DoLongOperation2(Task previusTask)
        {
            Console.WriteLine($"previusTask.Status = {previusTask.Status}");

            // Simulates a long-term operation
            Thread.Sleep(1000);
            Console.WriteLine($"Iso sono al termine di DoLongOperation(2)");
        }
    }
}
