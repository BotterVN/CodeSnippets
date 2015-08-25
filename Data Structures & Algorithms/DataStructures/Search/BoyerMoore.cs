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

            var bcTable = Enumerable.Repeat(-1, NUM_OF_ASCII_CHARS).ToArray();
            for (int n = 0; n < pattern.Length; n++)
                bcTable[pattern[n]] = n;

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
