using System;
using System.Collections.Generic;
using System.Text;

namespace PointClass
{
    /// <summary>
    /// Class of extention methods for <see cref="Point"/> class.
    /// </summary>
    public static class PointExtentions
    {
        /// <summary>
        /// Method of moving <see cref="Point"/> on the X axis.
        /// </summary>
        /// <param name="point">Left <see cref="Point"/> type parameter.</param>
        /// <param name="moveTo">Paramrter of <see cref="Double"/> type. Current <paramref name="point"/> travel distance.</param>
        /// <returns>Current <see cref="Point"/>.</returns>
        public static Point MoveX(this Point point, double moveTo)
        {
            point.X += moveTo;
            return point;
        }
        /// <summary>
        /// Method of moving <see cref="Point"/> on the Y axis.
        /// </summary>
        /// <param name="point">Left <see cref="Point"/> type parameter.</param>
        /// <param name="moveTo">Paramrter of <see cref="Double"/> type. Current <paramref name="point"/> travel distance.</param>
        /// <returns>Current <see cref="Point"/>.</returns>
        public static Point MoveY(this Point point, double moveTo)
        {
            point.Y += moveTo;
            return point;
        }
        /// <summary>
        /// Method of moving <see cref="Point"/> on the X and Y axis.
        /// </summary>
        /// <param name="point">Left <see cref="Point"/> type parameter.</param>
        /// <param name="moveX">Paramrter of <see cref="Double"/> type. Current <paramref name="point"/> <see cref="Point.X"/> travel distance.</param>
        /// <param name="moveY">Paramrter of <see cref="Double"/> type. Current <paramref name="point"/> <see cref="Point.Y"/> travel distance.</param>
        /// <returns>Current moved <see cref="Point"/>.</returns>
        public static Point MoveTo(this Point point, double moveX, double moveY)
        {
            point.X += moveX;
            point.Y += moveY;
            return point;
        }
        /// <summary>
        /// Method of moving current <see cref="Point"/> at new <see cref="Point"/> .
        /// </summary>
        /// <param name="point">Left <see cref="Point"/> type parameter.</param>
        /// <param name="moveTo">Paramrter of <see cref="Double"/> type. Current <paramref name="point"/> travel distance.</param>
        /// <returns>Current moved <see cref="Point"/>.</returns>
        public static Point MoveTo(this Point point, Point moveTo)
        {
            point.X += (moveTo.X - point.X);
            point.Y += (moveTo.Y - point.Y);
            return point;

        }
    }
}
