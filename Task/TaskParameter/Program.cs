using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParameter
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                object arg = i;
                Task.Factory.StartNew(DoStuff, arg);
            }

            // Press ENTER to exit
            Console.ReadLine();
        }


        private static void DoStuff(object num)
        {
            Console.WriteLine(num);
        }
    }
}
