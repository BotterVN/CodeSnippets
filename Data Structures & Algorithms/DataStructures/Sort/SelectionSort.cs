using BotterDSA.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    public class SelectionSort
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
                    BotterUtils.Swap(ref arr[minIdx], ref arr[i]);
                }
            }
        }
    }
}
