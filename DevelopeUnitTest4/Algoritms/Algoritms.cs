using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace Algoritms
{
    public static class Algoritms
    {
        //---- Public algoritms

        /// <summary>
        /// Two integer signed numbers and two positions of bits i and j 
        /// (i lesst than j)  are given. Implement an algorithm for inserting one number into another so that the second number occupies the position from bit j to bit i (bits are numbered from right to left).
        /// </summary>
        /// <param name="value">First value for changing bits. we change bits i this integer number.</param>
        /// <param name="insert">Secount integer for put it in first. <paramref name="value"/>.</param>
        /// <param name="left">position i.</param>
        /// <param name="right">position j.</param>
        public static int BitInsertAlgoritm(this int value, int insert, int left, int right)
        {
            if (left >= right || right > 31 || left < 0)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = left; i <= right; i++)
            {
                if (insert.GetBit(i)) // if in inserted integer in position i value true, back true
                {
                    SetBit(ref value, i, true); // set bit true in value on position i 
                }
                else SetBit(ref value, i, false); // set bit false in value on position i
            }
            return value;
        }

        /// <summary>
        /// Implement a recursive algorithm for searching the maximum element in unsorted array.
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int RecursiveAlgoritm(int[] array)
        {
            if (array != null)
            {
                int max = array[0];
                max = Loop(0, max, array); // enter loop
                return max;
            }
            else throw new NullReferenceException($"Array {array} is null.");
        }

        /// <summary>
        /// Given an array of integers. 
        /// Find and return an index n for which the sum of the elements 
        /// to the left of it is equal to the sum of the elements on the right. 
        /// If such an index does not return null (or -1).
        /// </summary>
        public static int EqualSumAlgoritm(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException($"Array {array} is null.");
            }

            int sum = 0;
            int leftsum = 0;

            foreach (var item in array)
            {
                sum += item; // summ of all elements in array
            }

            for (int i = 0; i < array.Length; ++i)
            {
                sum -= array[i];

                if (leftsum == sum) return i; // index we return

                leftsum += array[i]; // left part of array summ
            }

            return -1; // no good index
        }

        /// <summary>
        /// Two strings include only characters from 'a' to 'z', 
        /// return a concatenated alphabetized string, excluding duplicate characters.
        /// </summary>
        public static string TwoStrings(string left, string right)
        {
            if (left == null && right == null)
            {
                throw new NullReferenceException($"string is null");
            }

            TryFormat(left); // test of inputed strings.
            TryFormat(right);

            string concated = String.Concat(left, right); // Concate of strings
            char[] chars = concated.ToCharArray();
            Array.Sort(chars);

            var result = new string(chars.Distinct().ToArray());
            return result;
        }

        /// <summary>
        /// Write a method FilterLucky that accepts a list of integers and
        /// filters the list to only include the elements that contain the digit 7. 
        /// For example, FilterLucky(1,2,3,4,5,6,7,68,69,70,15,17) --> { 7, 70, 17 }.
        /// </summary>
        public static int[] FilterLucky(int[] array)
        {
            if (array == null)
            {
                throw new NullReferenceException($"Array {array.ToString()} is null.");
            }

            IEnumerable<string> list = ConvertMethod<string, int>(array, Convert.ToString);

            var lucky = list.Where(x => x.Contains('7'));

            IList<int> listint = ConvertMethod<int, string>(lucky.ToArray(), Convert.ToInt32);

            return listint.ToArray();
        }


        //---- Private metods

        /// <summary>
        /// Method for setting true1 or false0 bit.
        /// </summary>
        /// <param name="item">value where we change bit.</param>
        /// <param name="index">index of bit to change.</param>
        /// <param name="val">input true if set 1 and false if set 0.</param>
        /// <returns>result integer.</returns>
        private static void SetBit(ref int item, int index, bool val)
        {
            if (index > 32)
            {
                throw new IndexOutOfRangeException($"index {index} more than 32");
            }
            if (val)
                item |= (1 << index);
            else
                item &= ~(1 << index);
        }
        /// <summary>
        /// Extention method for getting bit in <paramref name="index"/> position.
        /// </summary>
        /// <param name="src">our integer where get bit at ingex.</param>
        /// <param name="index">position of bit.</param>
        /// <returns>Boolean if <paramref name="src"/> index back true or false.</returns>
        private static bool GetBit(this int src, int index)
        {
            return Convert.ToBoolean(src &= (1 << index));
        }

        /// <summary>
        /// Loop of recursive algoritm.
        /// </summary>
        /// <param name="i">idex of step.</param>
        /// <param name="max">current maximal integer in array.</param>
        /// <param name="array">array for continue.</param>
        /// <returns>Maximal integer in array.</returns>
        private static int Loop(int i, int max, int[] array)
        {
            if (i != array.Length)
            {
                if (array[i] > max) // if array[i] bigger than current max.
                {
                    max = array[i]; // new max.
                }
                i++;
                return Loop(i, max, array); // new iteration of loop.
            }
            return max;
        }
        /// <summary>
        /// Test of inputed strings. Strings must be only with letter format.
        /// </summary>
        /// <param name="left"></param>
        private static void TryFormat(string left)
        {
            foreach (var item in left)
            {
                if (!Char.IsLetter(item))
                {
                    throw new FormatException("Incorrest string. Can't consist of no letter Char.");
                }
            }
        }

        /// <summary>
        /// Method for FilterLucky to create list.
        /// </summary>
        /// <typeparam name="T">convert into this type list.</typeparam>
        /// <typeparam name="U">convert from this type list.</typeparam>
        /// <param name="array">array of <typeparamref name="U"/> type.</param>
        /// <param name="convert">method of converting.</param>
        /// <returns></returns>
        private static List<T> ConvertMethod<T,U>(U[] array, Func<U,T> convert)
        {
            List<T> list = new List<T>();

            foreach (var item in array)
            {
                T s = convert.Invoke(item);
                list.Add(s);
            }

            return list;
        }
    }
}
