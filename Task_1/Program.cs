using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{

    public delegate double Func(double a, double x);

    class Program
    {
        public static void Table(Func F, double a, double x, double b)
        {
            Console.WriteLine("----- A ------- X -------- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                x += 1;
            }
            Console.WriteLine("-----------------------------------");
        }
        public static double PowFunc(double a, double x)
        {
            return a * x * x;
        }

        public static double SinFunc(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            Console.WriteLine("Значения функции a*x^2:");
            Table(new Func(PowFunc), -1.5, -2, 2);

            Console.WriteLine("Значения функции a*sin(x):");
            Table(new Func(SinFunc), 3, -2, 2);


            Console.ReadKey();
        }
    }
}
