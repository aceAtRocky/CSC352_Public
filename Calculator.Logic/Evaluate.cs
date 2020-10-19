namespace Calculator.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

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

        public static string EvaluateRPN_StepByStepInfix(string rpn)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Parser.ConvertToInfix(rpn));
            Stack<double> evaluatorStack = new Stack<double>();
            string[] tokens = rpn.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < tokens.Length; i++)
            {
                if (tokens[i].Equals("+"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a + b;
                    sb.AppendLine($"Add {a} to {b} to get {result}");
                    evaluatorStack.Push(result);
                    sb.AppendLine(Parser.ConvertToInfix(GeneateCurrentRPN(evaluatorStack, tokens.Skip(i + 1))));
                }
                else if (tokens[i].Equals("-"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a - b;
                    sb.AppendLine($"Subtract {b} from {a} to get {result}");
                    evaluatorStack.Push(result);
                    sb.AppendLine(Parser.ConvertToInfix(GeneateCurrentRPN(evaluatorStack, tokens.Skip(i + 1))));
                }
                else if (tokens[i].Equals("/"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a / b;
                    sb.AppendLine($"Divide {a} by {b} to get {result}");
                    evaluatorStack.Push(result);
                    sb.AppendLine(Parser.ConvertToInfix(GeneateCurrentRPN(evaluatorStack, tokens.Skip(i + 1))));
                }
                else if (tokens[i].Equals("*"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = a * b;
                    sb.AppendLine($"Multiply {a} by {b} to get {result}");
                    evaluatorStack.Push(result);
                    sb.AppendLine(Parser.ConvertToInfix(GeneateCurrentRPN(evaluatorStack, tokens.Skip(i + 1))));
                }
                else if (tokens[i].Equals("^"))
                {
                    double b = evaluatorStack.Pop();
                    double a = evaluatorStack.Pop();
                    double result = Math.Pow(a, b);
                    sb.AppendLine($"Raise {a} to the {b} Power to get {result}");
                    evaluatorStack.Push(result);
                    sb.AppendLine(Parser.ConvertToInfix(GeneateCurrentRPN(evaluatorStack, tokens.Skip(i + 1))));
                }
                else
                {
                    double parsedDouble = double.Parse(tokens[i]);
                    evaluatorStack.Push(parsedDouble);
                }
            }

            sb.Append(evaluatorStack.Pop());

            return sb.ToString();
        }

        private static string GeneateCurrentRPN(Stack<double> evaluatorStack, IEnumerable<string> enumerable)
        {
            StringBuilder currentRPN = new StringBuilder();

            foreach (var current in evaluatorStack)
            {
                currentRPN.Append($"{current} ");
            }

            foreach (var current in enumerable)
            {
                currentRPN.Append($"{current} ");
            }

            return currentRPN.ToString().Trim();
        }

        public static double EvaluateInfix(string infix)
        {
            string rpn = Parser.ConvertToRPN(infix);
            return EvaluateRPN(rpn);
        }
    }
}
