using System;
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
                else if (isFunction(token))
                {
                    operatorStack.Push(token);
                }
                else if (isOperator(token))
                {
                    while
                        (
                            operatorStack.Any() &&
                            operatorStack.Peek() != "(" &&
                            (
                                OperatorHasGreaterPrecidence(operatorStack.Peek(), token)
                                ||
                                (OperatorHasEqualPrecidence(operatorStack.Peek(), token) && TokenIsLeftAssociative(token))
                            )
                        )
                    {
                        output.Enqueue(operatorStack.Pop());
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

        public static string ConvertToInfix(string rpn)
        {
            string[] splitRPN = rpn.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Stack<string> outputStack = new Stack<string>();

            for (int i = 0; i < splitRPN.Length; i++)
            {
                if (Parser.isOperator(splitRPN[i]))
                {
                    string right = outputStack.Pop();
                    string left = outputStack.Pop();
                    string result = $"{left} {splitRPN[i]} {right}";

                    // Now do the look ahead
                    for (int j = i + 1; j < splitRPN.Length; j++)
                    {
                        if (Parser.isOperator(splitRPN[j]))
                        {
                            if (Parser.OperatorHasGreaterPrecidence(splitRPN[j], splitRPN[i]))
                            {
                                result = $"( {result} )";
                            }

                            break;
                        }
                    }

                    outputStack.Push(result);
                }
                else
                {
                    outputStack.Push(splitRPN[i]);
                }
            }

            return outputStack.Pop();
        }

        internal static bool isFunction(string token)
        {
            switch (token)
            {
                case "sqrt":
                    {
                        return true;
                    }
                default:
                    {
                        return false;
                    }
            }
        }

        private static bool OperatorHasGreaterPrecidence(string op1, string op2)
        {
            int op1Precidence = GetOperatorPrecidence(op1);
            int op2Precidence = GetOperatorPrecidence(op2);

            return op1Precidence > op2Precidence;
        }

        private static int GetOperatorPrecidence(string op)
        {
            switch (op)
            {
                case "^":
                    {
                        return 3;
                    }
                case "*":
                case "/":
                    {
                        return 2;
                    }
                case "+":
                case "-":
                    {
                        return 1;
                    }
                default:
                    {
                        throw new InvalidOperationException("Unknown operator");
                    }
            }
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
            if (token == "^")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool isOperator(string token)
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
