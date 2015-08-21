using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Search
{
    public class KmpSearch
    {
        private int Search(string text, string word)
        {
            if (text.Length < word.Length)
            {
                return -1;
            }

            var i = 0;
            var nextPrefix = -1;
            var currentWordIndex = 0;
            while (i < text.Length)
            {
                if (text[i] == word[currentWordIndex])
                {
                    if (currentWordIndex == word.Length - 1)
                    {
                        return i - currentWordIndex;
                    }
                    
                    if (text[i] == word[0] 
                        && currentWordIndex != 0 
                        && nextPrefix < 0)
                    {
                        nextPrefix = i;
                    }
                    currentWordIndex++;
                    i++;
                }
                else
                {
                    i = nextPrefix > 0 ? nextPrefix : ++i;
                    currentWordIndex = 0;
                    nextPrefix = -1;
                }
            }
            return -1;
        }
    }
}
