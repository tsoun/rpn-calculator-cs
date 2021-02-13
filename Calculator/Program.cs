using System;
using System.Collections;

namespace Calculator // RPN - Reverse Polish Notation Calculator app developed in C sharp (2021)
{
    class MainApp
    {
        public static Stack stack;
        static Operators.Adder adder;
        static Operators.Subtructor subtractor;
        static Operators.Multiplier multiplier;
        static Operators.Divider divider;
        static Operators.ResultPresenter resultPresenter;

        static void Main(string[] args)
        {
            stack = new Stack();
            adder = new Operators.Adder();
            subtractor = new Operators.Subtructor();
            multiplier = new Operators.Multiplier();
            divider = new Operators.Divider();
            resultPresenter = new Operators.ResultPresenter();

            CalculatorApp calculator = new CalculatorApp(stack, adder, subtractor, divider, multiplier, resultPresenter);
        }

    }
    class CalculatorApp
    {
        static string expression;
        static int number;
        public CalculatorApp(Stack stack, Operators.Adder adder, Operators.Subtructor subtructor, Operators.Divider divider, 
            Operators.Multiplier multiplier, Operators.ResultPresenter resultPresenter)
        {
            // console version
            Console.WriteLine("Welcome to RPN Calculator in C sharp.\nPlease enter a string in the manner shown:\n1 (Enter) 5 (Enter) + (Enter).");
            Console.WriteLine("To finish your expression just type EXT.");
            while ((expression = Console.ReadLine()) != "EXT")
            {
                switch (expression)
                {
                    case "+":
                        adder.operate(stack);
                        break;
                    case "-":
                        subtructor.operate(stack);
                        break;
                    case "/":
                        divider.operate(stack);
                        break;
                    case "*":
                        multiplier.operate(stack);
                        break;
                    default:
                        if (int.TryParse(expression, out number))
                        {
                            stack.Push(number);
                        }
                        else
                        {
                            continue;
                        }
                        break;
                }
            }
            Console.WriteLine("The result is:\t");
            foreach (Object element in stack) // must be one if correct
            {
                Console.Write(element);
            }

        }
    }
}

namespace Operators
{
    interface Operator
    {
        void operate(Stack stack);
    }

    class Adder : Operator
    {
         public void operate(Stack stack)
         {
            try
            {
                int d1 = (int)stack.Pop();
                int d2 = (int)stack.Pop();
                int d3 = d1 + d2;

                stack.Push(d3);
            }
            catch
            {
                Console.WriteLine("Empty or with one element list.");
            }
         }
    }
    class Subtructor : Operator
    {
        public void operate(Stack stack)
        {
            try
            {
                int d1 = (int)stack.Pop();
                int d2 = (int)stack.Pop();
                int d3 = d2 - d1;

                stack.Push(d3);
            }
            catch
            {
                Console.WriteLine("Empty or with one element list.");
            }
        }

    }
    class Multiplier : Operator
    {
        public void operate(Stack stack)
        {
            try
            {
                int d1 = (int)stack.Pop();
                int d2 = (int)stack.Pop();
                int d3 = d1 + d2;

                stack.Push(d3);
            }
            catch
            {
                Console.WriteLine("Empty or with one element list.");
            }
        }

    }
    class Divider : Operator
    {
        public void operate(Stack stack)
        {
            try
            {
                int d1 = (int)stack.Pop();
                int d2 = (int)stack.Pop();
                int d3 = d2 / d1;

                stack.Push(d3);
            }
            catch
            {
                Console.WriteLine("Empty or with one element list.");
            }
        }

    }

    class ResultPresenter : Operator
    {
        public void operate(Stack stack)
        {
            try
            {
                int d1 = (int)stack.Pop();

                Console.WriteLine(stack);
            }
            catch
            {
                Console.WriteLine("Empty or with one element list.");
            }
        }
    }
}