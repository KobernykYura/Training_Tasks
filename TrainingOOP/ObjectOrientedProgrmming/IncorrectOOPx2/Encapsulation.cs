using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv2
{
    /// <summary>
    /// Нет инкапсуляции данных. Пользователь может воспользоваться  методом,
    /// который должен быть privte и используется в другом методе скрытно(ползователь не занает о реализации).
    /// </summary>    
    public static class Encapsulation
    {
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
                if (insert.GetBit(i)) // if in inserted integer in position i value true, back true        /*метод GetBit, который не должен быть публичным*/
                {
                    SetBit(ref value, i, true); // set bit true in value on position i              /*метод SetBit, который не должен быть публичным*/
                }
                else SetBit(ref value, i, false); // set bit false in value on position i           /*метод SetBit, который не должен быть публичным*/
            }
            return value;
        }

        //---- "Private" metods 
        // Пользователю необходимо предоставить только метод алгоритма BitInsertAlgoritm.
        // Открывать для него SetBit и GetBit не имеет смысла.

        /// <summary>
        /// Method for setting true1 or false0 bit.
        /// </summary>
        /// <param name="item">value where we change bit.</param>
        /// <param name="index">index of bit to change.</param>
        /// <param name="val">input true if set 1 and false if set 0.</param>
        /// <returns>result integer.</returns>
        public static void SetBit(ref int item, int index, bool val)
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
        public static bool GetBit(this int src, int index)
        {
            return Convert.ToBoolean(src &= (1 << index));
        }
    }
}
