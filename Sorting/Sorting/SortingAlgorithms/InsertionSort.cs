using System;
using System.Collections.Generic;
using System.Text;
using Sorting.Helper;
using Sorting.Interfaces;

namespace Sorting.SortingAlgorithms
{
    public class InsertionSort<T> : Tracker<T>, ISorter<T>
        where T : IComparable<T>
    {
        public void Sort(T[] items)
        {
            int startingIndex = 1;

            while (startingIndex < items.Length)
            {
                if (Compare(items[startingIndex], items[startingIndex - 1]) < 0)
                {
                    int insertIndex = FindInsertionIndex(items, items[startingIndex]);
                    Insert(items, insertIndex, startingIndex);
                }
                startingIndex++;
            }
        }

        private void Insert(T[] items, int indexInsertingAt, int indexInsertingFrom)
        {
            T buffer = items[indexInsertingAt];

            Assign(items, indexInsertingAt, items[indexInsertingFrom]);

            for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
            {
                Assign(items, current, items[current - 1]);
            }

            Assign(items, indexInsertingAt + 1, buffer);
        }

        private int FindInsertionIndex(T[] items, T valueToInsert)
        {
            for (int index = 0; index < items.Length; index++)
            {
                if (Compare(items[index], valueToInsert) > 0)
                {
                    return index;
                }
            }

            throw new InvalidOperationException("Insertion index not found");
        }
    }
}
