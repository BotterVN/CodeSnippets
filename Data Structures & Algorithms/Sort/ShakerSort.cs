using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    class ShakerSort
    {
        public void Sort(int[] arr)
        {
            int k = 0;
	        int left = 0;
	        int right = arr.Length - 1;

	        while (left < right) {
		        for (int i = right; i > left; i--) {
			        if (arr[i] < arr[i - 1]) {
				        Swap(ref arr[i], ref arr[i - 1]);
				        k = i;                        
			        }
                }
		        left = k;

		        for (int i = left; i < right; i++) {
			        if (arr[i] > arr[i + 1]) {
				        Swap(ref arr[i], ref arr[i + 1]);
				        k = i;                        
			        }
                }
		        right = k;
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
