﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Logic
{
    public class Parser
    {
        public static string ConvertToRPN(string equation)
        {
            Queue<string> output = new Queue<string>();
            Stack<string> operatorStack = new Stack<string>();

            string[] splitEquation = equation.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in splitEquation)
            {
                if (char.IsNumber(token.First()) || (token.Length > 1 && token.StartsWith("-")))
                {
                    output.Enqueue(token);
                }
                else if (isOperator(token))
                {
                    while
                        (
                            operatorStack.Any() &&
                            (
                                OperatorHasGreaterPrecidence(operatorStack.Peek(), token)
                                ||
                                (OperatorHasEqualPrecidence(operatorStack.Peek(), token) && TokenIsLeftAssociative(token))
                            )
                        )
                    {

                    }

                    operatorStack.Push(token);
                }
                else if (token.Equals("("))
                {
                    operatorStack.Push("(");
                }
                else if (token.Equals(")"))
                {
                    try
                    {
                        while (operatorStack.Peek() != "(")
                        {
                            output.Enqueue(operatorStack.Pop());
                        }

                        // Discard Left Paren "("
                        operatorStack.Pop();
                    }
                    catch (InvalidOperationException ex)
                    {
                        throw new InvalidOperationException("Unbalanced Parens!", ex);
                    }
                }
            }

            while (operatorStack.Any())
            {
                if (operatorStack.Peek() == "(")
                {
                    throw new InvalidOperationException("Unbalanced Parens!");
                }

                output.Enqueue(operatorStack.Pop());
            }

            StringBuilder sb = new StringBuilder();

            foreach (var outputElement in output)
            {
                sb.Append(outputElement);
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();

        }

        private static bool OperatorHasGreaterPrecidence(string v, string token)
        {
            throw new NotImplementedException();
        }

        public static bool OperatorHasEqualPrecidence(string v, string token)
        {
            bool hasEqualPrecidence = false;

            if (v == token)
            {
                hasEqualPrecidence = true;
            }
            else if (v == "+" || v == "-")
            {
                if (token == "+" || token == "-")
                {
                    hasEqualPrecidence = true;
                }
            }
            else if (v == "*" || v == "/")
            {
                if (token == "*" || token == "/")
                {
                    hasEqualPrecidence = true;
                }
            }

            return hasEqualPrecidence;
        }

        private static bool TokenIsLeftAssociative(string token)
        {
            return true;
        }

        private static bool isOperator(string token)
        {
            switch (token)
            {
                case "+":
                case "-":
                case "*":
                case "/":
                case "^":
                    return true;
                default:
                    return false;
            }
        }
    }
}

//public class OrderOfOperationComparer : IComparer<string>
//{
//    public int Compare(string x, string y)
//    {

//        // E(MD)(AS)
//        throw new NotImplementedException();
//    }

//    public int ConvertToValue(string op)
//    {
//        switch(op)
//        {
//            case "^":
//                {
//                    return 3;
//                }
//        }
//    }
//}
