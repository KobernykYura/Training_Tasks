using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    public class Color
    {
        /// <summary>
        /// Code of red.
        /// </summary>
        protected byte _red;
        /// <summary>
        /// Code of green.
        /// </summary>
        protected byte _green;
        /// <summary>
        /// Code of blue.
        /// </summary>
        protected byte _blue;

        /// <summary>
        /// Property of color name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property of color code.
        /// </summary>
        public string Code { get => (_red + _green + _blue).ToString(); }

        /// <summary>
        /// Default color constructor.
        /// </summary>
        public Color()
        {
            _red = 0;
            _green = 0;
            _blue = 0;
        }
        /// <summary>
        /// Constructor of red color only.
        /// </summary>
        /// <param name="red">Red color parameter.</param>
        public Color(byte red) : this()
        {
            _red = red;
        }
        /// <summary>
        /// Constructor of red and green in color.
        /// </summary>
        /// <param name="red">Red color parameter.</param>
        /// <param name="green">Green color parameter.</param>
        public Color(byte red, byte green):this(red)
        {
            _red = red;
            _green = green;
        }
        /// <summary>
        /// Constructor of red, green and blue in color.
        /// </summary>
        /// <param name="red">Red color parameter.</param>
        /// <param name="green">Green color parameter.</param>
        /// <param name="blue">Blue color parameter.</param>
        public Color(byte red, byte green, byte blue) : this(red, green) 
        {
            _red = red;
            _green = green;
            _blue = blue;
        }
    }
}
