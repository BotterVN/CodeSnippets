using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    public class InsertSort
    {
        public void Sort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                var insertElement = arr[i];

                // find a place to insert
                int insertIdx = 0;
                while (insertIdx < i && arr[insertIdx] < arr[i])
                    insertIdx++;

                // shift all later elements to the right
                var j = i;
                while (j > insertIdx)
                {
                    arr[j] = arr[j-1];
                    j--;
                }
                arr[insertIdx] = insertElement;
            }
        }
    }
}
