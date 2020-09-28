using System;
using System.Linq;
using System.Text;

public class Kata
{
    public static int SquareDigits(int n)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char current in n.ToString())
        {
            double currentInt = double.Parse(current.ToString());
            sb.Append(Math.Pow(currentInt, 2).ToString());
        }

        int.Parse(sb.ToString());
    }
}
