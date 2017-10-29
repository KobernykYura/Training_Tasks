using System;
using System.Collections.Generic;
using System.Text;

namespace AbstractClass
{
    public class Color
    {
        protected string _name;
        protected byte _red;
        protected byte _green;
        protected byte _blue;

        public string Name { get => _name; set => _name = value; }
        public string Code { get => (_red + _green + _blue).ToString(); }

        public Color()
        {
            _name = "White";
            _red = 0;
            _green = 0;
            _blue = 0;
        }
        public Color(string name, byte red)
        {
            _name = name;
            _red = red;
        }
        public Color(string name, byte red, byte green):this(name, red)
        {
            _name = name;
            _red = red;
            _green = green;
        }
        public Color(string name, byte red, byte green, byte blue) : this(name, red, green) 
        {
            _name = name;
            _red = red;
            _green = green;
            _blue = blue;
        }
    }
}
