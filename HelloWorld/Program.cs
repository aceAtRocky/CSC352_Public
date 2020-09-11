using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ExampleClassLibrary;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {

            for (var i = 1; i <= 10; i++)
            {
                Console.WriteLine($"This is the number {i} and it is cool");
            }

            int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        }

        static bool IsEven(int i)
        {
            return i % 2 == 0;
        }

        static bool IsSquare(int i)
        {
                var result = Math.Sqrt(i);
                return result == (int)result;
        }

        public static string SongDecoder(string input)
        {
            return string.Join(" ", input.Replace("WUB", " ").Split(" ", StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
