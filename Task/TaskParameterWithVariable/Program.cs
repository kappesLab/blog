using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParameterWithVariable
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    Console.WriteLine(i);
                });
            }

            // Press ENTER to exit
            Console.ReadLine();
        }
    }
}
