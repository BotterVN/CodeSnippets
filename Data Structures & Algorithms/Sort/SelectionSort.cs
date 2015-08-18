using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    class SelectionSort
    {
        public void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // find index of minimum element in unordered list
                var minIdx = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIdx])
                        minIdx = j;
                }

                // put minimum element to ordered list
                if (minIdx != i)
                {
                    var temp = arr[minIdx];
                    arr[minIdx] = arr[i];
                    arr[i] = temp;
                }
            }
        }
    }
}
