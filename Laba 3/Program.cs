using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;


namespace Laba_3
{
    internal class Program
    {
        static double CalcFactorial2(uint num)// факторіал без рекурсії
        {
            double factorial = 1;
            for (int i = 1; i <= num; i++)
            {
                factorial *= i;
            }
            return factorial;
        }
        static double CalcFactorial (uint num)//рекурсивний факторіал
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
        static double CalcExp2(double x, uint num = 0, double precision = 1e-10)
        {
            double result = 0;
            double current = 1;
            int pow = 0;
            while (current > precision)
            {
                current = (double)Math.Pow(x, pow) / CalcFactorial2((uint)num);
                result += current;
                num += 1;
                pow++;
            }
            return result;
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
        static double CalcCos2(double x, double precision = 1e-10, int f = -1,uint num = 0)
        {
            double result = 0;
            double current = 1;
            int pow = 0;
            while (Math.Abs(current) > precision)
            {
                current = Math.Pow(x, 2 * pow) / CalcFactorial2((uint)(2 * num));
                result += -f * current;
                pow++;
                num ++;
                f *= -1;
            }
            return result;
        }
        static void Main(string[] args)
        {
            int choice;
            do
            {
                Console.WriteLine("In order to calculate Exp type 1");
                Console.WriteLine("In order to calculate Exp with another variant type 2");
                Console.WriteLine("In order to calculate Cos type 3");
                Console.WriteLine("In order to calculate Cos with another variant type 4");
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
                        Console.WriteLine("Type x for Exp");
                         x = Convert.ToDouble(Console.ReadLine());
                        ResultExp = CalcExp2(x);
                        Console.WriteLine($"Exp(x)      = {ResultExp}");
                        Console.WriteLine($"Math.Exp(x) = {Math.Exp(x)} ");//Перевірка правильності знаходження
                        break;
                    case 3:
                        Console.WriteLine("Type x for Cos");
                        x = Convert.ToDouble(Console.ReadLine());
                        double ResultCos = CalcCos(x);
                        Console.WriteLine($"Cos(x)      = {ResultCos}");
                        Console.WriteLine($"Math.Cos(x) = {Math.Cos(x)}");//Перевірка правильності знаходження 
                        break;
                    case 4:
                        Console.WriteLine("Type x for Cos");
                        x = Convert.ToDouble(Console.ReadLine());
                        ResultCos = CalcCos2(x);
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