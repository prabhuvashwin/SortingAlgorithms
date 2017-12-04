using Sorting.Helper;
using Sorting.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting.SortingAlgorithms
{
    public class QuickSort<T> : Tracker<T>, ISorter<T>
        where T : IComparable<T>
    {
        Random _pivotRandom = new Random();

        public void Sort(T[] items)
        {
            Sort(items, 0, items.Length - 1);
        }

        private void Sort(T[] items, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = _pivotRandom.Next(left, right);
                int newPivot = Partition(items, left, right, pivotIndex);

                Sort(items, left, newPivot - 1);
                Sort(items, newPivot + 1, right);
            }
        }

        private int Partition(T[] items, int left, int right, int pivotIndex)
        {
            T pivotValue = items[pivotIndex];

            Swap(items, pivotIndex, right);

            int storeIndex = left;

            for (int i = left; i < right; i++)
            {
                if (Compare(items[i], pivotValue) < 0)
                {
                    Swap(items, i, storeIndex);
                    storeIndex += 1;
                }
            }

            Swap(items, storeIndex, right);
            return storeIndex;
        }
    }
}
