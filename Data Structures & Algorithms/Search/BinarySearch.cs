using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Search
{
    class BinarySearch
    {
        public int Search(int[] arr, int value)
        {
            int left = 0;
            int right = arr.Length - 1;
            int middle = -1;
		
	    while (left <= right) 
            {
		middle = (left + right) / 2;
                if (value == arr[middle])
                {
		    return middle;
		}
                else if (value < arr[middle])
                {
                    right = middle - 1;
                }
                else
                {
                    left = middle + 1;
                }                 	
	    }
            // value is not exist in array
            return -1;
        }        
    }
}
