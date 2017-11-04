using System;
using System.Collections.Generic;
using System.Text;

namespace PointClass
{
    /// <summary>
    /// Part of class with overrided operators.
    /// </summary>
    public partial class Point
    {
        /// <summary>
        /// + operator.
        /// </summary>
        /// <param name="first">Left parameter.</param>
        /// <param name="secound">Right paarmeter.</param>
        /// <returns>New Point object.</returns>
        public static Point operator +(Point first, Point secound)
        {
            return new Point(first.X + secound.X, first.Y + secound.Y);
        }
        /// <summary>
        /// - operator.
        /// </summary>
        /// <param name="first">Left parameter.</param>
        /// <param name="secound">Right parameter.</param>
        /// <returns>New Point object.</returns>
        public static Point operator -(Point first, Point secound)
        {
            return new Point(first.X - secound.X, first.Y - secound.Y);
        }
        /// <summary>
        /// ++ increment.
        /// </summary>
        /// <param name="point">incremented parameter.</param>
        /// <returns>New Point object.</returns>
        public static Point operator ++(Point point)
        {
            return new Point(point.X + 1, point.Y + 1);
        }
        /// <summary>
        /// -- decrement.
        /// </summary>
        /// <param name="point">decrement paarmeter.</param>
        /// <returns>New decremeented Point object.</returns>
        public static Point operator --(Point point)
        {
            return new Point(point.X - 1, point.Y - 1);
        }

        //----Overriding true and false.
        
        /// <summary>
        ///  operator true.
        /// </summary>
        /// <param name="point">parameter for booling.</param>
        /// <returns>true, if point not null, false if null.</returns>
        public static bool operator true(Point point)
        {
            return point != null;
        }
        /// <summary>
        /// operator false.
        /// </summary>
        /// <param name="point">parameter for booling.</param>
        /// <returns>true, if point null, false if not null.</returns>
        public static bool operator false(Point point)
        {
            return point == null;
        }

        //----Equality operators.

        /// <summary>
        /// Equality of two points.
        /// </summary>
        /// <param name="first">Left parameter.</param>
        /// <param name="secound">Right parameter.</param>
        /// <returns>Result <see cref="bool"/> of comparation.</returns>
        public static bool operator ==(Point first, Point secound)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(first, secound))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)first == null) || ((object)secound == null))
            {
                return false;
            }

            return (first.X == secound.X) && (first.Y == secound.Y);
        }
        /// <summary>
        /// Inequality of two <see cref="Point"/>.
        /// </summary>
        /// <param name="first">Left <see cref="Point"/> parameter.</param>
        /// <param name="secound">Right <see cref="Point"/> parameter.</param>
        /// <returns>Result of comparation elements.</returns>
        public static bool operator !=(Point first, Point secound)
        {
            // If both are null, or both are same instance, return true.
            if (ReferenceEquals(first, secound))
            {
                return false;
            }

            // If one is null, but not both, return false.
            if (((object)first == null) || ((object)secound == null))
            {
                return true;
            }

            return !(first.X == secound.X && first.Y == secound.Y);
        }
        /// <summary>
        /// More or equal of two <see cref="Point"/>.
        /// </summary>
        /// <param name="first">Left <see cref="Point"/> parameter.</param>
        /// <param name="secound">Right <see cref="Point"/> parameter.</param>
        /// <returns>Result of comparation elements.</returns>
        public static bool operator >=(Point first, Point secound)
        {
            // If one of parameters is null return false.
            if (((object)first == null) || ((object)secound == null))
            {
                return false;
            }

            return first.X >= secound.X && first.Y >= secound.Y;
        }
        /// <summary>
        /// Less or equal of two <see cref="Point"/>.
        /// </summary>
        /// <param name="first">Left <see cref="Point"/> parameter.</param>
        /// <param name="secound">Right <see cref="Point"/> parameter.</param>
        /// <returns>Result of comparation elements.</returns>
        public static bool operator <=(Point first, Point secound)
        {
            // If one of parameters is null return false.
            if ((object)first == null || (object)secound == null)
            {
                return false;
            }

            return first.X <= secound.X && first.Y <= secound.Y;
        }
        /// <summary>
        /// More than of two <see cref="Point"/>.
        /// </summary>
        /// <param name="first">Left <see cref="Point"/> parameter.</param>
        /// <param name="secound">Right <see cref="Point"/> parameter.</param>
        /// <returns>Result of comparation elements.</returns>
        public static bool operator >(Point first, Point secound)
        {
            // If one of parameters is null return false.
            if (((object)first == null) || ((object)secound == null))
            {
                return false;
            }

            return first.X > secound.X && first.Y > secound.Y;
        }
        /// <summary>
        /// Less than of two <see cref="Point"/>.
        /// </summary>
        /// <param name="first">Left <see cref="Point"/> parameter.</param>
        /// <param name="secound">Right <see cref="Point"/> parameter.</param>
        /// <returns>Result of comparation elements.</returns>
        public static bool operator <(Point first, Point secound)
        {
            // If one of parameters is null return false.
            if ((object)first == null || (object)secound == null)
            {
                return false;
            }

            return first.X < secound.X && first.Y < secound.Y;
        }

        /// <summary>
        /// Overrided Equal().
        /// </summary>
        /// <param name="obj">Object typr <see cref="Point"/> to compare.</param>
        /// <returns>Comparation result <see cref="bool"/>.</returns>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Point return false.
            Point point = obj as Point;
            if ((object)point == null)
            {
                return false;
            }

            return (point.X == _x) && (point.Y == _y);
        }
        /// <summary>
        /// Get hash code overrided method.
        /// </summary>
        /// <returns>Returns hash code of <see cref="int"/> type.</returns>
        public override int GetHashCode()
        {
            return (int)_x ^ (int)_y;
        }

    }
}
