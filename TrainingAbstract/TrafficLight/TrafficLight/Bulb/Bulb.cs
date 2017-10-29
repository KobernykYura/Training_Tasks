using System;
using System.Collections.Generic;
using System.Text;

namespace TrafficLight
{
    public class Bulb : AbstractBulb
    {
        private uint _currentDuration;  //----Тип прошедшего времени должен совпадать с типом времени работающей лампочки

        public uint CurrentDuration { get => _currentDuration; set => _currentDuration = value; }

        /// <summary>
        /// Конструктор по умолчанию задает значения лампочки.
        /// </summary>
        public Bulb() : base() 
        {
            this._currentDuration = 0;
        }
        /// <summary>
        /// Конструктор лампочки по заданным параметрам.
        /// </summary>
        /// <param name="currentDuration">Время, которое уже проработала эта лампочка.</param>
        /// <param name="company">Компания-производитель.</param>
        /// <param name="power">Мощность лампочки.</param>
        /// <param name="duration">Время жизни лампочки.</param>
        /// <param name="captype">ип цоколя лампочки.</param>
        public Bulb(uint currentDuration, string company, ushort power, uint duration, string captype) 
            : base(company, power, duration, captype)
        {
            this._currentDuration = currentDuration;
        }

        /// <summary>
        /// Включение лампочки
        /// </summary>
        public override bool OnOffBulb()
        {
            if (IsOn())
            {
                return _burns = false;
            }
            else return _burns = true;
        }
        /// <summary>
        /// Лампочка сломана, если ее время жизни превышает установленное.
        /// </summary>
        /// <returns>Результат сравнения текущего времени жизни и установленного.</returns>
        public override bool IsBroken()
        {
            return _currentDuration > _duration;
        }
        /// <summary>
        /// Указывает состояние лампочки в данный момент.
        /// </summary>
        /// <returns>Состояние лампочки.</returns>
        public override bool IsOn()
        {
            return Burns;
        }
        /// <summary>
        /// Заменим сломанную лампочку.
        /// </summary>
        /// <param name="company">Компания-производитель лампочки.</param>
        /// <param name="power">Мощность лампочки.</param>
        /// <param name="duration">Продолжительность работы лампочки.</param>
        /// <param name="captype">Тип цоколя.</param>
        public override void ChangeBulb(string company, ushort power, uint duration, string captype)
        {
            if (IsBroken())
            {
                this._company = company;
                this._power = power;
                this._duration = duration;
                this._captype = "Small";
            }
            else throw new Exception("Bulb is't broken. Change it only when it will be broken.",new ArgumentException());
        }
        /// <summary>
        /// Процесс работы горения.
        /// </summary>
        /// <param name="time"></param>
        public override void Working(uint time)
        {
            _currentDuration += time;  //----Увеличение времени работы лампочки

            if (_currentDuration < _duration)
            {
                _burns = true;
            }
            else throw new Exception("Время жизни лампочки истекло! Замените лампочку.");
        }
    }
}
