using System;
using System.Collections.Generic;
using System.Linq;

namespace SimprintsChallenges
{
    public class QuickSort
    {
        public List<int> DoQuickSort(List<int> array)
        {
            return Sort(array, 0, array.Count -1);
        }

        private List<int> Sort(List<int> array, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = PerformPartitioning(array, left, right);

                Sort(array, left, (pivotIndex - 1) < left ? left : (pivotIndex - 1));
                Sort(array, (pivotIndex + 1) > right ? right : (pivotIndex + 1), right);
            }
            return array;
        }

        private int PerformPartitioning(List<int> array, int start, int end)
        {
            //Selecting the first element as a Pivot.
            int pivotIndex = start;
            int pivot = array[pivotIndex];
            int swapIndex = start;

            for (int i = start + 1; i <= end; i++)
            {
                if (pivot > array[i])
                {
                    swapIndex++;
                    Swap(array, swapIndex, i);
                }
            }

            Swap(array, pivotIndex, swapIndex);
            return swapIndex;
        }

        private void Swap(List<int> array, int first, int second)
        {
            int tmp = array[first];
            array[first] = array[second];
            array[second] = tmp;
        }

    }
}
