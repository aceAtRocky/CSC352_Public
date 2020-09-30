namespace CountDuplicates
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Kata
    {
        public static int DuplicateCount(string str)
        {
            var charsInString = str.AsEnumerable().Select(currentChar => char.ToLower(currentChar));

            var result = new Dictionary<char, int>();

            foreach (var charInString in charsInString)
            {
                if (!result.ContainsKey(charInString))
                {
                    result.Add(charInString, 0);
                }

                result[charInString]++;
            }

            return result.Where(kvp => kvp.Value > 1).Count();
        }
    }
}
