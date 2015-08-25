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
            var jj = 0;
            for (var i = len - 1; i >= 0; --i)
                if (suffixs[i] == i + 1)
                    for (; jj < len - 1 - i; ++jj)
                        if (gsTable[jj] == len)
                            gsTable[jj] = len - 1 - i;
            for (var i = 0; i <= len - 2; ++i)
                gsTable[len - 1 - suffixs[i]] = len - 1 - i;

            var idx = 0;
            while(idx < s.Length-pattern.Length)
            {
                int idx2 = pattern.Length-1;
                while (idx2 >= 0 && s[idx + idx2] == pattern[idx2])
                    idx2--;

                if (idx2 == -1)
                    return idx;

                //bc = Math.Max(1, idx2-bcTable[s[idx+idx2]]);
                gs = gsTable[idx2];

                idx += Math.Max(bc, gs);
            }

            return -1;
        }
    }
}
