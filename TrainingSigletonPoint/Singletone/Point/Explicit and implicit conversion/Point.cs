using System;
using System.Collections.Generic;
using System.Text;

namespace PointClass
{
    public partial class Point
    {
        //----Implicit convertion.

        /// <summary>
        /// Implicit convertion <see cref="Point"/> to <see cref="double"/>.
        /// </summary>
        /// <param name="point"><see cref="Point"/> to conversion.</param>
        public static implicit operator double(Point point)
        {
            return point.X + point.Y;
        }
        /// <summary>
        /// Implicit conversion <see cref="Point"/> to <see cref="int"/>.
        /// </summary>
        /// <param name="point"><see cref="Point"/> to conversion.</param>
        public static implicit operator int(Point point)
        {
            return (int)point.X + (int)point.Y;
        }

        //----Explicit convertion.

        /// <summary>
        /// Explicit conversion <see cref="Point"/> to <see cref="string"/>.
        /// </summary>
        /// <param name="point">String of <see cref="Point"/>.</param>
        public static explicit operator string(Point point)
        {
            if ((object)point == null)
            {
                return "null";
            }
            return $"{point.X} {point.Y}";
        }
        /// <summary>
        /// Explicit conversion <see cref="int"/> to <see cref="Point"/>.
        /// </summary>
        /// <param name="intValue">New object of <see cref="Point"/> type.</param>
        public static explicit operator Point(int intValue)
        {
            return new Point(intValue, intValue);
        }
        /// <summary>
        /// Explicit conversion <see cref="double"/> to <see cref="Point"/>.
        /// </summary>
        /// <param name="doubleValue">New object of <see cref="Point"/>.</param>
        public static explicit operator Point(double doubleValue)
        {
            return new Point(doubleValue, doubleValue);
        }
        /// <summary>
        /// Overrided <see cref="Object"/> method. 
        /// </summary>
        /// <returns>Result <see cref="string"/> type.</returns>
        public override string ToString()
        {
            return $"This:{this.GetType()} X:{X} Y:{Y}";
        }

    }
}
