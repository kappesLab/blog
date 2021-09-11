using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;


namespace ThreadPoolWithDelegate
{
    class Program
    {
        // delegate declaration
        delegate void MyDelegate(string str);

        static void Main(string[] args)
        {
            // MyDelegate" instantiation
            MyDelegate delegateInstance = DoStuff;

            // asynchronous delegate invocation
            delegateInstance.BeginInvoke("Davide", null, null);

            // synchronous delegate invocation
            //delegateInstance.Invoke("Davide");

            Console.WriteLine("Io sono nel thread pricipale.");

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoStuff(string name)
        {
            Thread.Sleep(500);
            Console.WriteLine($"Ciao {name}, Io sono in un thread del 'ThreadPool'");
        }
    }
}
