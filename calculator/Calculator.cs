using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    internal static class Calculator
    {
        public static double Operation(double num1,double num2)
        {
            return num1 + num2;
        }
        public static double difference(double num1, double num2)
        {
            return num1 - num2;
        }
        public static double compositiom(double num1, double num2)
        {
            return num1 * num2;
        }
        public static double division(double num1, double num2)
        {
            return num1 / num2;
        }
    }
}
