using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Search
{
    public class BoyerMoore
    {
        public int Search(string s, string pattern)
        {
            var bc = -1;
            var gs = -1;

            // bad character rule
            var NUM_OF_ASCII_CHARS = (int)(Math.Pow(2, 8) - 1);

            var bcTable = new int[NUM_OF_ASCII_CHARS];
            for (int n = 0; n < s.Length; n++)
            {
                int idx = pattern.Length - 1;
                while (idx >= 0 && pattern[idx] != s[n])
                    idx--;
                bcTable[s[n]] = idx;
            }

            // good suffix rule

            var i = 0;
            while(i < s.Length-pattern.Length)
            {
                int j = pattern.Length-1;
                while (j >= 0 && s[i + j] == pattern[j])
                    j--;

                if (j == -1)
                    return i;

                bc = Math.Max(1, j-bcTable[s[i+j]]);

                i += Math.Max(bc, gs);
            }

            return -1;
        }
    }
}
