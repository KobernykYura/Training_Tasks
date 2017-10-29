using System;

namespace AbstractClass
{
    public abstract class AbsractPicture : ISavable, IChageable
    {
        protected uint _height;
        protected uint _width;
        protected DateTime _creationDate;
        protected Color[] _colors;

        public uint Height { get => _height; set => _height = value; }
        public uint Width { get => _width; set => _width = value; }
        public DateTime Creation { get => _creationDate; set => _creationDate = value; }
        public Color[] Colors { get => _colors; set => _colors = value; }

        public AbsractPicture()
        {
            this._height = 100;
            this._width = 50;
            this._creationDate = DateTime.Now;
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
        /// Full constructor of picture class.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        /// <param name="age">Age of picture.</param>
        /// <param name="popular">If this picture popular.</param>
        public AbsractPicture(uint height, uint width, DateTime age) : this(height, width) 
        {
            this._creationDate = age;
        }

        public abstract void ReWrite(uint height, uint width, Color[] colors);
        public abstract void ReWrite(uint height, uint width);
        public abstract void ReWrite(Color[] colors);
        public abstract void Clean();
        public abstract void Delete();
        public abstract void Save();
        public abstract void SaveAs(string path);
    }
}
