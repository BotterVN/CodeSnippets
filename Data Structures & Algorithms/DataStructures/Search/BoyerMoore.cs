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

            // good suffix rule

            for (int i = 0; i < s.Length; i++)
            {
                int j;
                for (j = pattern.Length-1; j >= 0; j--)
                {
                    if(s[i+j] != pattern[j])
                        break;
                    else if(j == 0)
                        return i;
                }

                int k;
                //
                var badCharacter = s[i + j];
                k = j - 1;
                while (k >= i && pattern[k] != badCharacter)
                    k--;

                bc = i + j - k - 1;

                //
                // find pattern p[j+1:len]
                var substringLen = pattern.Length - (j + 1);

                if (substringLen != 0)
                {
                    k = i + pattern.Length - 2;
                    bool isMatch = false;
                    while (k >= i && !isMatch)
                    {
                        isMatch = true;
                        for (int l = 0; l < substringLen; l++)
                        {
                            if (s[j + 1 + l] != pattern[l])
                                isMatch = false;
                        }
                    }
                    gs = i + j - k - 1;
                }
                else
                    gs = pattern.Length - 1;

                i += Math.Max(bc, gs);
            }

            return -1;
        }
    }
}
