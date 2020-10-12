namespace Calculator.Logic
{
    using System;
    using System.Collections.Generic;

    public class Evaluate
    {
        public static double EvaluateRPN(string rpn)
        {
            Stack<double> evaluatorStack = new Stack<double>();
            string[] tokens = rpn.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var token in tokens)
            {
                if (token.Equals("+"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a + b;
                    evaluatorStack.Push(result);
                }
                else if (token.Equals("-"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a - b;
                    evaluatorStack.Push(result);
                }
                else if (token.Equals("/"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a / b;
                    evaluatorStack.Push(result);
                }
                else if (token.Equals("*"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a * b;
                    evaluatorStack.Push(result);
                }
                else if (token.Equals("^"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = Math.Pow(a, b);
                    evaluatorStack.Push(result);
                }
                else
                {
                    double parsedDouble = double.Parse(token);
                    evaluatorStack.Push(parsedDouble);
                }
            }

            return evaluatorStack.Pop();
        }

        public static double EvaluateInfix(string infix)
        {
            string rpn = Parser.ConvertToRPN(infix);
            return EvaluateRPN(rpn);
        }
    }
}
