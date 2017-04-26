// Calculator. Console application in C#.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculate
    {
        static void Main()
        {
            double firstNumber;
            double secondNumber;
            string operation;
            double result = 0;

            Console.WriteLine("Please enter the first number");
            firstNumber = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Please enter the operation /, *, -, +");
            operation = Console.ReadLine();
            Console.WriteLine("Please enter the second number");
            secondNumber = Convert.ToDouble(Console.ReadLine());

            switch (operation)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        Console.WriteLine("Division by zero is forbidden");
                        break;
                    }
                    else
                    {
                        result = firstNumber / secondNumber;
                        break;
                    } 

            }

            Console.WriteLine("Result = {0}", result.ToString());
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();


        }
    }
}
