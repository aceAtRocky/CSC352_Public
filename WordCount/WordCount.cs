// <copyright file="UnitTests.cs" company="Ace Olszowka">
// Copyright (c) 2020 Ace Olszowka.
// </copyright>

namespace WordCount
{
    using System;
    using System.Collections.Generic;

    public static class WordCount
    {
        public static IDictionary<string, int> CountWords(string phrase)
        {
            IDictionary<string, int> dictionary = new Dictionary<string, int>();

            string[] splitCharacters =
                new string[]
                {
                    " ",
                    ",",
                    "\n",
                };

            string[] splitPhrases = phrase.Split(splitCharacters, StringSplitOptions.RemoveEmptyEntries);

            foreach (string splitPhrase in splitPhrases)
            {
                string sanitizedPhrase = SanitizePhrase(splitPhrase);

                if (dictionary.ContainsKey(sanitizedPhrase))
                {
                    dictionary[sanitizedPhrase] = dictionary[sanitizedPhrase] + 1;
                }
                else
                {
                    dictionary.Add(sanitizedPhrase, 1);
                }
            }

            return dictionary;
        }

        internal static string SanitizePhrase(string splitPhrase)
        {
            string[] forbiddenCharacters =
                new string[]
                {
                    "!",
                    "@",
                    "#",
                    "$",
                    "%",
                    "^",
                    "&",
                    "*",
                    "!",
                    "?",
                    ":",
                    ",",
                    ".",
                };

            foreach (string forbiddenChar in forbiddenCharacters)
            {
                splitPhrase = splitPhrase.Replace(forbiddenChar, string.Empty);
            }

            return splitPhrase.ToLower();
        }
    }
}
