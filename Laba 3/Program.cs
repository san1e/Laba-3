using System.Reflection.Metadata.Ecma335;

namespace Laba_3
{
    internal class Program
    {
        static double CalcFactorial (uint num)
        {
            if (num <= 1)
            {
                return 1;
            }
            return num * CalcFactorial(num - 1);
        }
        static double CalcExp (double x, int n = 0, double precision = 1e-10)
        {
          double current = Math.Pow(x, n) / CalcFactorial((uint)n);
            if (current < precision )
            {
                return current;
            }
            return current + CalcExp(x, n + 1, precision);
        }
        static double CalcCos (double x, int n = 0, double precision = 1e-10,int f = -1)
        {
            
            double result = -f * Math.Pow(x, 2 * n) / CalcFactorial((uint)(2 * n));
            if (Math.Abs(result) < precision)
            {
                return result;
            }
            return result + CalcCos(x, n + 1, precision,f*-1);
            
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("In order to calculate Exp type 1");
                Console.WriteLine("In order to calculate Cos type 2");
                Console.WriteLine("To stop the programm type 0");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Type x for Exp");
                        double x = Convert.ToDouble(Console.ReadLine());
                        double ResultExp = CalcExp(x);
                        Console.WriteLine($"Exp(x)      = {ResultExp}");
                        Console.WriteLine($"Math.Exp(x) = {Math.Exp(x)} ");//Перевірка правильності знаходження 
                        break;
                    case 2:
                        Console.WriteLine("Type x for Cos");
                        x = Convert.ToDouble(Console.ReadLine());
                        double ResultCos = CalcCos(x);
                        Console.WriteLine($"Cos(x)      = {ResultCos}");
                        Console.WriteLine($"Math.Cos(x) = {Math.Cos(x)}");//Перевірка правильності знаходження 
                        break;
                    case 0:
                        Console.WriteLine("On more time push Enter to stop programm");
                        Console.ReadLine();
                        break;

                }

            } while (choice != 0);
            
        }
    }
}