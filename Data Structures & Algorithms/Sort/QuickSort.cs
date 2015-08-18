using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    public class QuickSort
    {
        public void Sort(int[] m, int leftIdx, int rightIdx)
        {
            if (leftIdx < rightIdx)
            {
                var pivot = Partition(m, leftIdx, rightIdx);
                Sort(m, leftIdx, pivot - 1);
                Sort(m, pivot + 1, rightIdx);
            }
        }

        private int Partition(int[] m, int leftIdx, int rightIdx)
        {
            // get pivot as the left most element of the array
            var pivot = m[rightIdx];
            var i = leftIdx;

            for (var j = leftIdx; j < rightIdx; j++)
			{
                if (m[j] <= pivot) 
                {
                    var tmp = m[i];
                    m[i] = m[j];
                    m[j] = tmp;

                    i++;
                }
			}
           
            var tm = m[rightIdx];
            m[rightIdx] = m[i];
            m[i] = tm;

            return i;
        }
    }
}
