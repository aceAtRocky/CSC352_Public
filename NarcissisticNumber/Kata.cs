using System;

public class Kata
{
    public static bool Narcissistic(int value)
    {
        int numberOfDigits = value.ToString().Length;

        double runningTotal = 0;

        foreach (Char digit in value.ToString())
        {
            runningTotal += Math.Pow(int.Parse(digit.ToString()), numberOfDigits);
        }

        return runningTotal == value;
    }
}
