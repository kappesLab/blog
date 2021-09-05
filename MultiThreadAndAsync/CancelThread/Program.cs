using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CancelThread
{
    class Program
    {
        static volatile bool isThreadCancel = false;

        static void Main(string[] args)
        {
            Thread th = new Thread(DoStuff);
            th.Name = "ThreadStuff";
            th.Priority = ThreadPriority.Normal;
            th.Start();

            Console.WriteLine("Premi ENTER per blocaare 'ThreadStuff'");
            Console.ReadLine();
            isThreadCancel = true;
            th.Join();

            Console.WriteLine("Io sono nel thread pricipale.");

            // Press ENTER to exit
            Console.ReadLine();
        }

        private static void DoStuff()
        {
            while(!isThreadCancel)
            {
                Console.WriteLine("Io sono nel 'ThreadStuff'");
                Thread.Sleep(1000);
            }
        }
    }
}
