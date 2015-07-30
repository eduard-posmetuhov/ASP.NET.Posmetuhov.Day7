using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinSearchLib
{
    public class BinarySearch
    {
        public static int Search<T>(T[]array,T value)
        {
            if (array == null)
            {
                throw new ArgumentNullException("Bad array");
            }
            if (!(value is IComparable<T>))
            {
                throw new InvalidOperationException("Value not implement the interface IComparable");
            }
            return BinarySearchAlgorithm(array, value, Compare);
        }

        public static int Search<T>(T[] array, T value, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException("Bad array");
            }
            if (array.Length == 0)
            {
                return -1;
            }
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException("Bad array comparer");
            }
            return BinarySearchAlgorithm(array, value, comparer.Compare);
        }

        public static int Search<T>(T[] array, T value, Comparison<T> comparison)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException("Bad array");
            }
            if (array.Length == 0)
            {
                return -1;
            }
            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException("Bad array comparison");
            }
            return BinarySearchAlgorithm(array, value, comparison);
        }

        private static int Compare<T>(T a, T b)
        {
            if (ReferenceEquals(a, b))
            {
                return 0;
            }
            if (ReferenceEquals(a, null))
            {
                return -1;
            }
            var comparable = a as IComparable<T>;
            if (comparable == null)
            {
                throw new ArgumentNullException("Value in array not implement the interface IComparable");
            }
            return comparable.CompareTo(b);
        }

        private static int BinarySearchAlgorithm<T>(T[] array, T value, Comparison<T> comparison)
        {
            int left = 0;
            int right = array.Length - 1;
            while (right >= left)
            {
                int middle = (left + right) / 2;
                if (comparison(array[middle], value) > 0)
                {
                    right = middle - 1;
                }
                else
                if (comparison(array[middle], value) < 0)
                {
                    left = middle + 1;
                }
                else
                {
                    return middle;
                }
            }
            return -1;
        }
    }
}
