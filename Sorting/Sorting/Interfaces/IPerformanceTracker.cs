using System;
using System.Collections.Generic;
using System.Text;

namespace Sorting.Interfaces
{
    public interface IPerformanceTracker
    {
        long Comparisons { get; }
        long Swaps { get; }
        void Reset();
    }
}
