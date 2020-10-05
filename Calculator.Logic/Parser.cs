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
                else
                {
                    operatorStack.Push(token);
                }
            }

            StringBuilder sb = new StringBuilder();

            foreach(var outputElement in output)
            {
                sb.Append(outputElement);
                sb.Append(" ");
            }

            return sb.ToString().TrimEnd();

        }
    }
}
