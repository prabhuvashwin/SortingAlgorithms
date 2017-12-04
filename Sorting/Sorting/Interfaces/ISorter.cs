using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting.Interfaces
{
    public interface ISorter<T> : IPerformanceTracker
        where T : IComparable<T>
    {
        void Sort(T[] items);
    }
}
