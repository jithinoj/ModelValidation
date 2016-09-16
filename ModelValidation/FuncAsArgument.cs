using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelValidation
{
    public class FuncionAsArgumentUsingDeligate
    {

        public delegate double MyFunction(double x);

        public double Diff(double x, MyFunction f)
        {
            double h = 10;

            return (f(x + h) - f(x));
        }

        public double MyFunctionMethod(double x)
        {
            // Can add more complicated logic here
            return x + 10;
        }

        public void Client()
        {
            double result = Diff(1, x => x * 10);
            double secondResult = Diff(2, MyFunctionMethod);

            Console.WriteLine("From FuncionAsArgumentUsingDeligate:");
            Console.WriteLine(result);
            Console.WriteLine(secondResult);

        }

    }

    public class FuncionAsArgumentUsingFunc
    {

        public double Diff(double x, Func<double, double> f)
        {
            double h = 21;

            return (f(x + h) - f(x));
        }

        public void Calculate() {

            Console.WriteLine("From FuncionAsArgumentUsingFunc:");

            double result = Diff(4, d => Math.Sqrt(d));
            Console.WriteLine(result);
        }

    }


    public class FuncTest
    {

        public string RemoveUnderscoreName(string x, Func<string, bool> f)
        {
            if (f(x))
                return x.Replace('_', ' ');
            else
                return string.Empty;
        }

        public void Calculate()
        {

            Console.WriteLine("From FuncTest :- ");

            string result = RemoveUnderscoreName("Jithin Joy", d => d.Length == 10);

            Console.WriteLine(result);
        }

    }
}
