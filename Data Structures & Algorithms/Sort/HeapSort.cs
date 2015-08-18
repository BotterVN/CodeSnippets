using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Botter.CodeSnippets.DSA.Sort
{
    public class HeapSort
    {
        public void Sort(int[] arr)
        {
            // build heap
            for (int i = arr.Length / 2-1; i >= 0; i--)
            {
                Heapify(arr, i, arr.Length);
            }

            // sort
            var heapSize = arr.Length;
            for (int i = arr.Length - 1; i > 0; i--)
            {
                Swap(arr, i, 0);
                heapSize--;
                Heapify(arr, 0, heapSize);
            }
        }

        #region Heap Helpers
        private void Heapify(int[] arr, int idx, int heapSize)
        {
            if (idx >= heapSize / 2)
                return;

            var left = Left(idx);
            var right = Right(idx);

            var largest = idx;

            if (left < heapSize && arr[left] > arr[idx])
                largest = left;

            if (right < heapSize && arr[right] > arr[largest])
                largest = right;

            if (largest != idx)
            {
                Swap(arr, largest, idx);
                Heapify(arr, largest, heapSize);
            }
        }

        private int Left(int idx)
        {
            return idx * 2 + 1;
        }

        private int Right(int idx)
        {
            return idx * 2 + 2;
        }
        #endregion

        #region Helpers
        private void Swap(int[] arr, int i, int j)
        {
            var temp = arr[i];
            arr[i] = arr[j];
            arr[j] = temp;
        }
        #endregion
    }
}
