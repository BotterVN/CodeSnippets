using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    class InterchangeSort
    {
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
		for (int j = i + 1; j < arr.Length; j++) 
                {
                    if (arr[j] < arr[i])
                    {
                        Swap(ref arr[j], ref arr[i]);				        
		    }
		}		
	    }
        }
        public void Swap(ref int a, ref int b)
        {
            a = a + b;
            b = a - b;
            a = a - b;
        }
    }
}
