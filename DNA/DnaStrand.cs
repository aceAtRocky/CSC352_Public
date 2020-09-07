using System.Collections.Generic;
using System.Text;

public class DnaStrand
{
    public static string MakeComplement(string dna)
    {
        var replacements =
          new Dictionary<char, char>
          {
              {'T','A'},
              {'A','T'},
              {'C','G'},
              {'G','C'},
          };


        StringBuilder sb = new StringBuilder();

        foreach (var currentChar in dna)
        {
            sb.Append(replacements[currentChar]);
        }

        return sb.ToString();
    }
}
