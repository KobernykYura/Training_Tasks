using System;
using System.Collections.Generic;
using System.Text;

namespace CloudAbstractCloud
{
    public class Direction
    {
        /// <summary>
        /// Т.к. задается направление вектора, то он может быть отрицателен, но большие значения излишни.
        /// </summary>
        private sbyte _abscissa;
        private sbyte _ordinate;

        public sbyte Abscissa { get => _abscissa; set => _abscissa = value; }
        public sbyte Ordinate { get => _ordinate; set => _ordinate = value; }

        public Direction(sbyte abscissa, sbyte ordinate)
        {
            this._abscissa = abscissa;
            this._ordinate = ordinate;
        }
    }
}
