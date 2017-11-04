using System;

namespace AbstractClass
{
    /// <summary>
    /// Abstract class for constructing Picture.
    /// </summary>
    public abstract class AbsractPicture : ISavable, IChageable
    {
        /// <summary>
        /// Field of height. Only positive values.
        /// </summary>
        protected uint _height;
        /// <summary>
        /// Field of width. Only positive values.
        /// </summary>
        protected uint _width;
        /// <summary>
        /// Field of creation <see cref="DateTime"/>.
        /// </summary>
        protected DateTime _creationDate;
        /// <summary>
        /// Field of colors <see cref="Color"/>.
        /// </summary>
        protected Color[] _colors;


        /// <summary>
        /// Property of Height field.
        /// </summary>
        public uint Height { get => _height; set => _height = value; }
        /// <summary>
        /// Property of Width field.
        /// </summary>
        public uint Width { get => _width; set => _width = value; }
        /// <summary>
        /// Property of <see cref="DateTime"/> field.
        /// </summary>
        public DateTime Creation { get => _creationDate; set => _creationDate = value; }
        /// <summary>
        /// Property of <see cref="Color"/> field.
        /// </summary>
        public Color[] Colors { get => _colors; set => _colors = value; }


        /// <summary>
        /// Default constructor.
        /// </summary>
        public AbsractPicture()
        {
            this._height = 100;
            this._width = 50;
            this._creationDate = DateTime.Now;
            this._colors = new Color[2] { new Color(0 ,0 ,0), new Color(255, 255, 255) };
        }
        /// <summary>
        /// Constructor for hight and width of picture.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        public AbsractPicture(uint height, uint width) : this()
        {
            this._height = height;
            this._width = width;
        }
        /// <summary>
        /// Constructor for hight and width of picture.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        /// <param name="colors">Colors on picture.</param>
        public AbsractPicture(uint height, uint width, Color[] colors) : this(height, width)
        {
            this._height = height;
            this._width = width;
            this._colors = colors;
        }
        /// <summary>
        /// Full constructor of picture class.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        /// <param name="colors">Colors on picture.</param>
        /// <param name="age">Age of picture.</param>
        public AbsractPicture(uint height, uint width, Color[] colors, DateTime age) : this(height, width, colors) 
        {
            this._creationDate = age;
        }
        /// <summary>
        /// Method for rewriting current picture with new color <paramref name="colors"/>, height <paramref name="height"/> and width <paramref name="width"/>.
        /// </summary>
        /// <param name="height">Hight of the picture.</param>
        /// <param name="width">Width of the picture.</param>
        /// <param name="colors">Colors what collored this picture. </param>
        public abstract void ReWrite(uint height, uint width, Color[] colors);
        // <summary>
        /// Method for rewriting current picture with new height <paramref name="height"/> and width <paramref name="width"/>.
        /// </summary>
        /// <param name="height">Hight of the picture.</param>
        /// <param name="width">Width of the picture.</param>
        public abstract void ReWrite(uint height, uint width);
        /// <summary>
        /// Method for rewriting current picture with new color <paramref name="colors"/>.
        /// </summary>
        /// <param name="colors">Colors what collored this picture. </param>
        public abstract void ReWrite(Color[] colors);
        /// <summary>
        /// Set null value to colors and <see cref="DateTime.UtcNow"/> to age.
        /// </summary>
        public abstract void Clean();
        /// <summary>
        /// Method for deleting picture. 
        /// </summary>
        public abstract void Delete();
        /// <summary>
        /// Save to default path.
        /// </summary>
        public abstract void Save();
        /// <summary>
        /// Save to setted path <paramref name="path"/>. 
        /// </summary>
        /// <param name="path">Path to file.</param>
        public abstract void SaveAs(string path);
    }
}
