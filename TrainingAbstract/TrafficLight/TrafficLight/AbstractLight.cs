using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLight
{
    public abstract class AbstractLight
    {
        private byte _height;        //----Высота светофора врятли будет слишком велика
        private byte _width;        //----Ширина светофора врятли будет слишком велика

        private string _material;           //----Материал изготовления
        private DateTime _creationDate;     //----Дата выпуска
        private DateTime _maximumDate;     //----Дата выпуска

        protected byte Height { get => _height; set => _height = value; }
        protected byte Width { get => _width; set => _width = value; }
        protected string Material { get => _material; set => _material = value; }
        protected DateTime CreationDate { get => _creationDate; set => _creationDate = value; }
        protected DateTime MaximumDate { get => _maximumDate; set => _maximumDate = value; }

        /// <summary>
        /// Конструктор абстрактного светофора по умолчанию.
        /// </summary>
        public AbstractLight()
        {
            this._height = 200;
            this._width = 50;

            this._material = "Железо";
            this._creationDate = new DateTime(1998, 12, 23);
            this.MaximumDate = MaximumOperatingDate(20);
        }
        /// <summary>
        /// Конструктор частей светофора.
        /// </summary>
        /// <param name="height">Высота светофара.</param>
        /// <param name="width">Ширина светофора.</param>
        /// <param name="material">Материал светофора.</param>
        /// <param name="dateTime">Дата создания. </param>
        public AbstractLight(byte height, byte width, string material, DateTime dateTime)
        {
            this.Height = height;
            this.Width = width;

            this.Material = material;
            this.CreationDate = dateTime.Date;
            this.MaximumDate = MaximumOperatingDate(20);
        }

        /// <summary>
        /// Максимальная дата функционирования
        /// </summary>
        /// <param name="conting">Количество лет бесперебойной работы.</param>
        /// <returns>Дата до которой он будет исправно работать.</returns>
        private DateTime MaximumOperatingDate(int conting)
        {
            return CreationDate.AddYears(conting);  //----Возвращаем максимальную дату 
        }
    }
}
