using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    class Program
    {
        // delegate type declaration
        public delegate string PerformCalculation(double a, double b);
       
        static void Main(string[] args)
        {
            double x = 18.255;
            double y = 0.312;

            // Declaration of the instance variable of type PerformCalculation
            // (which is a delegate)
            PerformCalculation handler;

            // Method association
            handler = Calculation1;

            // Execution of the "Calculation1" method through the delegate
            Console.WriteLine($"{handler(x, y)} = Calculation1({x}, {y})");

            // Method association
            handler = Calculation2;

            // Execution of the "Calculation1" method through the delegate
            Console.WriteLine($"{handler(x, y)} = Calculation2({x}, {y})");

            // Press ENTER to exit
            Console.ReadLine();
        }

        public static string Calculation1(double x, double y)
        {
            double result = x + y;
            return Math.Round(result, 2).ToString();
        }

        public static string Calculation2(double x, double y)
        {
            double result = x * y;
            return Math.Round(result, 2).ToString();
        }
    }
}
