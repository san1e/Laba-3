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
        static void Main(string[] args)
        {
            //uint Fact = (uint)CalcFactorial(Convert.ToUInt32(Console.ReadLine()));
            //Console.WriteLine(Fact);
            double x = Convert.ToDouble(Console.ReadLine());
            double result = CalcExp(x);
            Console.WriteLine("Exp(x)      = {0}", result);
            Console.WriteLine("Math.Exp(x) = {0}", Math.Exp(x));
        }
    }
}