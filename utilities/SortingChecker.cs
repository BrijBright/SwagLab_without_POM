using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLab.utilities
{
    public static class SortingChecker
    {
        // Check if List<string> is sorted in ascending order
        public static bool IsSortedAscending(List<string> list)
        {
            if (list == null || list.Count <= 1)
                return true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (string.Compare(list[i], list[i + 1], StringComparison.Ordinal) > 0)
                    return false;
            }

            return true;
        }

        // Check if List<string> is sorted in descending order
        public static bool IsSortedDescending(List<string> list)
        {
            if (list == null || list.Count <= 1)
                return true;

            for (int i = 0; i < list.Count - 1; i++)
            {
                if (string.Compare(list[i], list[i + 1], StringComparison.Ordinal) < 0)
                    return false;
            }

            return true;
        }

        // Check if float[] array is sorted in ascending order
        public static bool IsLowToHigh(List<float> array)
        {
            if (array == null || array.Count <= 1)
                return true;

            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] > array[i + 1])
                    return false;
            }

            return true;
        }

        // Check if float[] array is sorted in descending order
        public static bool IsHightoLow(List<float> array)
        {
            if (array == null || array.Count <= 1)
                return true;

            for (int i = 0; i < array.Count - 1; i++)
            {
                if (array[i] < array[i + 1])
                    return false;
            }

            return true;
        }


    }
}
