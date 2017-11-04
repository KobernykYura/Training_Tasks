using System;

namespace PointClass
{
    /// <summary>
    /// Part of the class with fields, properties, constructors.
    /// </summary>
    public partial class Point
    {
        private double _x;
        private double _y;

        /// <summary>
        /// Constructor of <see cref="Point"/> with X asix.
        /// </summary>
        /// <param name="X">Parameter of <see cref="Double"/> type.</param>
        public Point(double X)
        {
            this.X = X;
        }
        /// <summary>
        /// Constructor of <see cref="Point"/> with X and Y asixs.
        /// </summary>
        /// <param name="X">Parameter of <see cref="Double"/> type.</param>
        /// <param name="Y">Parameter of <see cref="Double"/> type.</param>
        public Point(double X, double Y) : this(X) 
        {
            this.Y = Y;
        }

        /// <summary>
        /// Property of X asix.
        /// </summary>
        public double X { get => _x; set => _x = value; }
        /// <summary>
        /// Property of Y asix.
        /// </summary>
        public double Y { get => _y; set => _y = value; }
        
    }
}
