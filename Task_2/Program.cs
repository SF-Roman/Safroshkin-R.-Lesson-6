using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        delegate double Func(double a, double x);

        private static double PowFunc(double a, double x)
        {
            return a * x * x;
        }

        private static double SinFunc(double a, double x)
        {
            return a * Math.Sin(x);
        }

        public static void FuncAccept(string fileName, double a, double b, double c, int FN)
        {
            
            Func onFunc;
            if (FN == 1)
            {
                onFunc = PowFunc;
            }
            else 
            {
                onFunc = SinFunc;
            }

            FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            BinaryWriter binReader = new BinaryWriter(fileStream);
            double x = a;
            while (x <= b)
            {
                binReader.Write(onFunc.Invoke(a, x));
                x += c;
            }
            binReader.Close();
            fileStream.Close();
        }
        public static double Load(string fileName)
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fileStream);
           
            double F_min = double.MaxValue;
            double d;

            for (int i = 0; i < fileStream.Length / sizeof(double); i++)
            {
                d = binReader.ReadDouble();
                if (d < F_min) F_min = d;
            }
            binReader.Close();
            fileStream.Close();
            return F_min;
        }

        public static int[] Menu()
        {
            int[] var = new int[3];

            Console.Write("Выберите функцию:\n Цифра 1 - a*x^2;\n Цифра 2 - a*sin(x):\n ");
            var[0] = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Введите отрезок, на котором будем искать минимум.\n" +
                "Первое число - начало отрезка, второе число - конец отрезка:\n ");
            var[1] = Convert.ToInt32(Console.ReadLine());
            var[2] = Convert.ToInt32(Console.ReadLine());

            return var;
        }

        static void Main(string[] args)
        {
            int[] variables = Menu();

            FuncAccept("data.bin", variables[1], variables[2], 0.5, variables[0]);
            Console.WriteLine(Load("data.bin"));

            Console.ReadKey();
        }
    }
}
