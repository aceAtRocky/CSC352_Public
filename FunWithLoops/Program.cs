namespace FunWithLoops
{
    using System;
    using System.Collections.Generic;

    class Program
    {
        internal static IEnumerable<int> NumbersOneThruTwentyFive()
        {
            //List<int> numbers = new List<int>();

            //for(int i=1;i<=25;i++)
            //{
            //    numbers.Add(i);
            //}

            //return numbers;

            for (int i = 1; i <= 25; i++)
            {
                yield return i;
            }

        }

        internal static IEnumerable<int> EvenNumbersOneThruTwentyFive()
        {
            for (int i = 2; i <= 25; i += 2)
            {
                yield return i;
            }
        }

        internal static IEnumerable<int> AllEvenNumbers()
        {
            for (int i = 2; i <= int.MaxValue; i += 2)
            {
                yield return i;
            }
        }

        internal static IEnumerable<int> OddNumbersOneThruTwentyFive()
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<int> PrimeNumbersOneThruTwentyFive()
        {
            throw new NotImplementedException();
        }

        internal static bool IsPrime(int number)
        {
            bool isPrime = false;

            // Any Positive Interger
            // Divisible by 1 and itself

            if (number == 2)
            {
                isPrime = true;
            }
            else if (number > 2)
            {
                if (number % 2 == 0)
                {
                    isPrime = false;
                }
                else
                {
                    isPrime = true;

                    for (int i = 3; i < number; i++)
                    {
                        if (number % i == 0)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }
            }

            return isPrime;
        }

        internal static IEnumerable<int> GetNumbersOneThru(int thruInclusive)
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<int> GetRangeThruInclusive(int start, int end)
        {
            throw new NotImplementedException();
        }

        internal static IEnumerable<int> GetPrimesInRangeInclusive(int start, int end)
        {
            throw new NotImplementedException();
        }
    }
}
