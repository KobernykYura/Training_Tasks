using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLight
{
    public class Lighter : AbstractLight, IFixable
    {
        private Bulb _green;    //----Для разных ветофоров разное количество ламп
        private Bulb _yellow;
        private Bulb _red;

        /// <summary>
        /// Конструктор светофора по умолчанию.
        /// </summary>
        public Lighter() : base()
        {
            this._green = new Bulb(0, "Panasonic", 90, 200, "E45");
            this._red = new Bulb(0, "Panasonic", 90, 200, "E45");
            this._yellow = new Bulb(0, "Panasonic", 90, 200, "E45");
        }
        /// <summary>
        /// Конструктор светофора с заданным набором типа лампочек.
        /// </summary>
        /// <param name="red">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        /// <param name="yellow">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        /// <param name="green">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        public Lighter(Bulb red, Bulb yellow, Bulb green) : base()
        {
            this._green = red;
            this._red = yellow;
            this._yellow = green;
        }
        /// <summary>
        /// Конструктор светофора с заданным набором лампочек типа <see cref="TrafficLight.Bulb"/> и характеристик светофора.
        /// </summary>
        /// <param name="red">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        /// <param name="yellow">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        /// <param name="green">Объект лампы типа<see cref="TrafficLight.Bulb"/>.</param>
        public Lighter(Bulb red, Bulb yellow, Bulb green, byte height, byte width, string material, DateTime dateTime) 
            : base(height, width, material, dateTime)
        {
            this._green = red;
            this._red = yellow;
            this._yellow = green;
        }
        /// <summary>
        /// Включить светофор на определенное время.
        /// </summary>
        /// <param name="time">Время работы светофора.</param>
        public void StartLighter(uint time)
        {
            if (DateTime.Now.Date < MaximumDate)
            {
                //----Включили наш светофор
                On();

                if (!_red.IsBroken() && !_yellow.IsBroken() && !_green.IsBroken())
                {
                    _red.Working(time);
                    _yellow.Working(time * 2);        //----Он работает по некоторой логике и ломается
                    _green.Working(time);
                }
                else throw new Exception("Сломалась одна из лампочек, замените ее!");

                //----Выключили светофор в конце рабочего дня
                OffAll();   
            }
            else throw new Exception("Светофор устарел, замените его.");
        }

        /// <summary>
        /// Метод замены ламп.
        /// </summary>
        /// <param name="bulb">Лампа на замену.</param>
        public void FixBulbs(Bulb bulb)
        {
            Fix(_red, bulb);        ///----Поочередно проверяем и при необходимости заменям элементы
            Fix(_yellow, bulb);
            Fix(_green, bulb);
        }
        /// <summary>
        /// Метод починки светофора
        /// </summary>
        /// <param name="bulb">Новая лампа в новый светофор.</param>
        /// <param name="lighter">Новый светофор.</param>
        public void FixLighter(Bulb bulb, Lighter lighter)
        {
            Material = lighter.Material;
            Height = lighter.Height;
            CreationDate = lighter.CreationDate;

            Fix(_red, bulb);        ///----Поочередно проверяем и при необходимости заменям элементы
            Fix(_yellow, bulb);
            Fix(_green, bulb);
        }
        /// <summary>
        /// Проверка необходимости замены лампы.
        /// </summary>
        /// <param name="broken">Объект лампы, подозреваемой в поломке.</param>
        /// <param name="bulb">Объект новой лампочки.</param>
        private void Fix(Bulb broken, Bulb bulb )
        {
            if (broken.IsBroken())
            {
                broken = bulb;
            }
        }
        /// <summary>
        /// Включаем светофор
        /// </summary>
        private void On()
        {
            if (_green != null && _yellow != null && _red != null)
            {
                this._red.Burns = true;
                this._green.Burns = false;
                this._yellow.Burns = false;
            }
            else throw new Exception("Проверьте, вставлены ли лампочки у светофора.");
        }
        /// <summary>
        /// Выключаем светофор
        /// </summary>
        private void OffAll()
        {
            this._red.Burns = false;
            this._yellow.Burns = false;
            this._green.Burns = false;
        }
    }
}
