using System;
using System.Collections.Generic;
using System.Text;

namespace CloudAbstractCloud
{
    public class Coordinate
    {
        /// <summary>
        /// Координаты могут быть отрицательны, но вычисление новых координат требует тип <see cref="System.Int32"/>.
        /// </summary>
        private int _grad;
        private int _minuts;
        private int _seconds;

        public int Gradus { get => _grad; set => _grad = value; }
        public int Minuts { get => _minuts; set => _minuts = value; }
        public int Seconds { get => _seconds; set => _seconds = value; }

        public Coordinate(int grad, int minut, int second)
        {
            this._grad = grad;
            this._minuts = Math.Abs(minut);
            this._seconds = Math.Abs(second);
        }
    }
}
