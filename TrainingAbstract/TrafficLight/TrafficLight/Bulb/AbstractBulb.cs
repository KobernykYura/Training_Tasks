using System;

namespace TrafficLight
{
    public abstract class AbstractBulb : IOnable, IChangeable
    {
        protected string _company;      //----Производитель лампочки
        protected ushort _power;        //----Значение мощности лампочки только положительное
        protected uint _duration;       //----Продолжительность работы только положительная
        protected string _captype;      //----Тип цоколя

        protected bool _burns = false;  //----Состояние вкл/выкл

        public bool Burns { get => _burns; set => _burns = value; }
        public ushort Power { get => _power; }
        public string Company { get => _company; }

        /// <summary>
        /// Конструктор задает значения по умолчанию.
        /// </summary>
        public AbstractBulb()
        {
            _company = "";
            _power = 200;
            _duration = 50000;
            _captype = "E47";
        }
        /// <summary>
        /// Конструктор лампочки со всеми ее параметрами, вводимыми извне.
        /// </summary>
        /// <param name="company"></param>
        /// <param name="power"></param>
        /// <param name="cost"></param>
        /// <param name="duration"></param>
        /// <param name="captype"></param>
        public AbstractBulb(string company, ushort power, uint duration, string captype)
        {
            this._company = company;
            this._power = power;
            this._duration = duration;
            this._captype = captype;
        }
        /// <summary>
        /// Выключение/выключение лампочки.
        /// </summary>
        public abstract bool OnOffBulb();
        /// <summary>
        /// Указывает состояние лампочки в данный момент.
        /// </summary>
        /// <returns>Состояние лампочки.</returns>
        public abstract bool IsOn();
        /// <summary>
        /// Лампочка вышла из строя.
        /// </summary>
        /// <returns>Возвращает true, если время жизни лампочки рамно нулю.</returns>
        public abstract bool IsBroken();
        /// <summary>
        /// Заменим сломанную лампочку.
        /// </summary>
        /// <param name="company">Компания-производитель лампочки.</param>
        /// <param name="power">Мощность лампочки.</param>
        /// <param name="duration">Продолжительность работы лампочки.</param>
        /// <param name="captype">Тип цоколя.</param>
        public abstract void ChangeBulb(string company, ushort power, uint duration, string captype);
        /// <summary>
        /// Процесс работы врремени работы лампочки.
        /// </summary>
        /// <param name="time">Время работы.</param>
        public abstract void Working(uint time);
    }
}
