using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;

namespace AbstractClass
{
    /// <summary>
    /// Class of Picture.
    /// </summary>
    public class Picture : AbsractPicture
    {
        private string PATH_TO_FILE = @"..\..\Xml_Documents\picture2.xml"; 


        /// <summary>
        /// Default constructor from base class <see cref="AbsractPicture"/>.
        /// </summary>
        public Picture() : base() 
        {

        }
        /// <summary>
        /// Constructor for hight and width of picture.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        public Picture(uint height, uint width) : base(height, width)
        {
            this._height = height;
            this._width = width;
        }
        /// <summary>
        /// Constructor for hight and width of picture with colors.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        /// <param name="colors">Colors of picture.</param>
        public Picture(uint height, uint width, Color[] colors) : base(height, width, colors)
        {

        }
        /// <summary>
        /// Full constructor of picture class.
        /// </summary>
        /// <param name="height">Hight of picture.</param>
        /// <param name="width">Wigth of picture.</param>
        /// <param name="colors">Colors of picture.</param>
        /// <param name="age">Age of picture.</param>
        public Picture(uint height, uint width, Color[] colors, DateTime age) : base(height, width, colors) 
        {
            this._creationDate = age;
        }


        /// <summary>
        /// Method for rewriting current picture with new color <paramref name="colors"/>, height <paramref name="height"/> and width <paramref name="width"/>.
        /// </summary>
        /// <param name="height">Hight of the picture.</param>
        /// <param name="width">Width of the picture.</param>
        /// <param name="colors">Colors what collored this picture. </param>
        public override void ReWrite(uint height, uint width, Color[] colors)
        {
            this.Height = height;
            this.Width = width;
            this.Colors = colors;
            this.Creation = DateTime.UtcNow;
        }
        /// <summary>
        /// Method for rewriting current picture with new height <paramref name="height"/> and width <paramref name="width"/>.
        /// </summary>
        /// <param name="height">Hight of the picture.</param>
        /// <param name="width">Width of the picture.</param>
        public override void ReWrite(uint height, uint width)
        {
            this.Height = height;
            this.Width = width;
            this.Creation = DateTime.UtcNow;
        }
        /// <summary>
        /// Method for rewriting current picture with new color <paramref name="colors"/>.
        /// </summary>
        /// <param name="colors">Colors what collored this picture. </param>
        public override void ReWrite(Color[] colors)
        {
            this.Colors = colors;
            this.Creation = DateTime.UtcNow;
        }
        /// <summary>
        /// Set null value to colors and to <see cref="DateTime.UtcNow"/> age.
        /// </summary>
        public override void Clean()
        {
            this.Colors = null;
            this.Creation = DateTime.UtcNow;
        }
        /// <summary>
        /// Method for deleting picture. 
        /// </summary>
        public override void Delete()
        {
            this.Height = 0;
            this.Width = 0;
            this.Colors = null;
            this.Creation = DateTime.MinValue;
        }
        /// <summary>
        /// Save to default path.
        /// </summary>
        public override void Save()
        {
            using (FileStream stream = new FileStream(PATH_TO_FILE,FileMode.OpenOrCreate))
            {
                XDocument xdoc = XDocument.Load(stream);
                XElement root = xdoc.Element("Pictures");

                root.AddFirst(new XElement("Picture",
                new XAttribute("Creation", this.Creation),
                new XElement("Colors", this.Colors[0].Code),
                new XElement("Last", this.Height),
                new XElement("Gender", this.Width)));
                xdoc.Save(stream);
            }
        }
        /// <summary>
        /// Save to setted path <paramref name="path"/>. 
        /// </summary>
        /// <param name="path">Path to file.</param>
        public override void SaveAs(string path)
        {
            PATH_TO_FILE = path;

            using (FileStream stream = new FileStream(PATH_TO_FILE, FileMode.OpenOrCreate, FileAccess.Write))
            {
                XDocument xdoc = XDocument.Load(stream);
                XElement root = xdoc.Element("Pictures");

                root.AddFirst(new XElement("Picture",
                new XAttribute("Creation", this.Creation),
                new XElement("Colors", this.Colors),
                new XElement("Last", this.Height),
                new XElement("Gender", this.Width)));
                xdoc.Save(stream);
            }
        }
        
    }
}
