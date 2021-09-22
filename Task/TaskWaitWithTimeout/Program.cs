using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TakWaitWithTimeout
{
    class Program
    {
        static void Main(string[] args)
        {
            Task output = Task.Factory.StartNew(DoLongOperation);
            output.Wait(1500);

            Console.WriteLine($"output.Status = {output.Status}");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoLongOperation()
        {
            // Simulates a long-term operation
            for (int i = 0; i < 6; i++)
            { 
                Console.WriteLine($"Iso sono in DoLongOperation - LOOP:{i}");
                Thread.Sleep(500);
            }
            Console.WriteLine($"Iso sono al termine di DoLongOperation");
        }
    }
}
