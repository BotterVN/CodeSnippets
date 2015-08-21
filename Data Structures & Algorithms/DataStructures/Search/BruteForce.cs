using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Search
{
    public class BruteForce
    {
        public int Search(string data, string key) 
        {
            int limit = data.Length - key.Length + 1;

            for (int i = 0; i < limit; i++)
            {
                int j = 0;
                while (j < key.Length && key[j] == data[i + j]) 
                    j++;
                if (j == key.Length) return i;                
            }
            return -1;
        }
    }
}
