using System;
using System.Collections.Generic;
using System.Text;
using Sorting.Helper;
using Sorting.Interfaces;

namespace Sorting.SortingAlgorithms
{
    public class SelectionSort<T> : Tracker<T>, ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            int startingIndex = 0;

            while (startingIndex < items.Length)
            {
                int insertIndex = FindIndexOfSmallestElement(items, startingIndex);
                Swap(items, startingIndex, insertIndex);

                startingIndex++;
            }
        }

        private int FindIndexOfSmallestElement(T[] items, int startingIndex)
        {
            T currentSmallest = items[startingIndex];
            int currentSmallestIndex = startingIndex;

            for (int i = startingIndex + 1; i < items.Length; i++)
            {
                if (Compare(currentSmallest, items[i]) > 0)
                {
                    currentSmallest = items[i];
                    currentSmallestIndex = i;
                }
            }

            return currentSmallestIndex;
        }
    }
}
