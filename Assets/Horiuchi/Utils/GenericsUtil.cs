using System;
using System.Collections.Generic;

namespace SUtility
{
    public static class GenericsUtil
    {
        /// <summary>
        /// right と left を入れ替え
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="right"></param>
        /// <param name="left"></param>
        public static void Swap<T>(ref T right, ref T left)
        {
            T temp = left;
            left = right;
            right = temp;
        }

        /// <summary>
        /// 配列 の right と left を入れ替え
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="right"></param>
        /// <param name="left"></param>
        public static void Swap<T>(ref IList<T> list, int right, int left)
        {
            T temp = list[right];
            list[right] = list[left];
            list[left] = temp;
        }

        /// <summary>
        /// 値が範囲内か
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">対象</param>
        /// <param name="low">下範囲</param>
        /// <param name="high">上範囲</param>
        /// <param name="inclusive">境界を含むか</param>
        /// <returns></returns>
        public static bool isBetween<T>(this T value, T low, T high, bool inclusive = true) where T : IComparable<T>
        {
            if (low.CompareTo(high) > 0)
            {
                T temp = low;
                low = high;
                high = temp;
            }

            if (inclusive)
            {
                return low.CompareTo(value) <= 0 && value.CompareTo(high) <= 0;
            }
            else
            {
                return low.CompareTo(value) < 0 && value.CompareTo(high) < 0;
            }
        }

        public static void QuickSort<T>(this IList<T> list, Func<T, T, int> compare)
        {
            var stack = new Stack<int>();
            stack.Push(list.Count - 1);
            stack.Push(0);

            while (stack.Count > 0)
            {
                int left = stack.Pop();
                int right = stack.Pop();

                if (left >= right) continue;

                int pivotIndex = Partition(list, left, right, compare);

                stack.Push(right);
                stack.Push(pivotIndex + 1);
                stack.Push(pivotIndex - 1);
                stack.Push(left);
            }
        }

        private static int Partition<T>(IList<T> list, int left, int right, Func<T, T, int> compare)
        {
            int pivotIndex = Random.Range(left, right);
            T pivotValue = list[pivotIndex];
            Swap(ref list, pivotIndex, right);

            pivotIndex = left;

            for (int i = left; i < right; i++)
            {
                if (compare(list[i], pivotValue) < 0)
                {
                    Swap(ref list, i, pivotIndex);
                    pivotIndex++;
                }
            }

            Swap(ref list, pivotIndex, right);
            return pivotIndex;
        }
    }
}
