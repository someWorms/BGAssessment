using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorter
{
    /// <summary>
    /// Quick sort recursive algorithm
    /// </summary>
    public class Sort
    {
        /// <summary>
        /// Validates input data, proceeds to algorihm if validation passed.
        /// Creates necessary borders for algorithm internally
        /// </summary>
        /// <param name="data">Input array</param>
        /// <param name="offset">left border offset</param>
        /// <returns>sorted array</returns>
        /// <exception cref="ArgumentException">If validation is not passed.</exception>
        public static double[] VerifyAndSort(double[] data, int offset = 0)
        {
            if(data == null || data.Length == 0 || data.Length > 10)
            {
                throw new ArgumentException("Array should must contain from 1 to 10 elements");
            }

            // if data length is 1, we just return same array, w/o extra invocation.
            if(data.Length == 1)
            {
                return data;
            }

            int min = 0 + offset;
            int max = data.Length - 1;

            return QuickSortAlg(data, min, max);
        }
        private static double[] QuickSortAlg(double[] data, int min, int max)
        {
            if(min >= max)
            {
                return data;
            }

            int pivotIndex = GetPivotIndex(data, min, max);

            QuickSortAlg(data, min, pivotIndex - 1);

            QuickSortAlg(data, pivotIndex + 1, max);

            return data;
        }

        private static int GetPivotIndex(double[] data, int min, int max)
        {
            int pivotIndex = min - 1;

            for (int i = min; i <= max; i++)
            {
                if (data[i] < data[max])
                {
                    pivotIndex++;
                    Swap(ref data[pivotIndex], ref data[i]);
                }
            }

            pivotIndex++;
            Swap(ref data[pivotIndex], ref data[max]);

            return pivotIndex;
        }

        private static void Swap(ref double left,  ref double right)
        {
            double temp = left; 
            left = right;
            right = temp;
        }
    }
}
