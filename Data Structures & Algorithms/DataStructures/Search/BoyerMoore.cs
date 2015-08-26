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
            var gsTable = Enumerable.Repeat(pattern.Length, pattern.Length).ToArray();
            var suffixs = Enumerable.Repeat(0, pattern.Length).ToArray();

            for (int i = 0; i < pattern.Length; i++)
            {
                int j = i;
                while (j >= 0 && pattern[j] == pattern[pattern.Length - i - 1 + j])
                    j--;

                suffixs[i] = i-j;
            }

            var len = pattern.Length;
            for (var i = 0; i < len; ++i)
                gsTable[i] = len;
            for (var i = len - 1; i >= 0; --i)
                if (suffixs[i] == i + 1)
                    for (var j = 0; j < len - 1 - i; ++j)
                        if (gsTable[j] == len)
                            gsTable[j] = len - 1 - i;
            for (var i = 0; i <= len - 2; ++i)
                gsTable[len - 1 - suffixs[i]] = len - 1 - i;

            // run algorithm
            for (var i = 0; i < s.Length - pattern.Length; )
            {
                int j = pattern.Length - 1;
                while (j >= 0 && s[i + j] == pattern[j])
                    j--;

                if (j == -1)
                    return i;

                bc = Math.Max(1, j - bcTable[s[i + j]]);
                gs = gsTable[j];

                i += Math.Max(bc, gs);
            }

            return -1;
        }
    }
}
