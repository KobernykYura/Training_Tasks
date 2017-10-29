using System;
using System.Collections.Generic;
using System.Text;

namespace CloudAbstractCloud
{
    public abstract class AbstractCloud
    {
        protected const uint CRITICAL_MASS = 7000000;
        protected const uint CRITICAL_VOLUME = 70000000;

        //----Тип выбран в связи с невозможностью принимать значения <0
        protected const uint RAIN_MASS = 10;
        protected const uint SNOW_MASS = 5;
        protected const uint HAIL_MASS = 20;

        //----Тип выбран в связи с невозможностью принимать значения <0
        protected const uint RAIN_VOLUME = 100;
        protected const uint SNOW_VOLUME = 50;
        protected const uint HAIL_VOLUME = 200;

        //----Тип выбран в связи с возможностью принимать отрицательные значения. Граничные условия выпадения осадков.
        protected const short RAIN_SNOW_TEMPERATURE = -10;
        protected const short SNOW_HAIL_TEMPERATURE = -15;

        protected string _type;       //----Назватие типа облака
        protected ulong _mass;        //----Масса не может быть отрицательна, учтена масса облака на Юпитере
        protected ulong _volume;      //----Объем не может быть отрицательным учтен объем облака на Юпитере
        protected string _material;   //----Материал облаком различен для планет, экологии
        protected uint _height;        //----Высота облака не может быть отрицательна

        protected Direction _direction;       //----Направление движения облака
        protected Coordinate _previousCoord;  //----Предидущая координата облака
        protected Coordinate _currentCoord;   //----Настоящая координата облака
        protected double _traveledDist;       //----Пройденное расстояние только положительно
        protected bool _statical;             //----Двигается ли облако

        protected short _temperature;     //----Облака возможны при положительных и отрицательных значениях температур

        /// <summary>
        /// Значения по умолчанию
        /// </summary>
        public AbstractCloud()
        {
            this._type = "Usual";
            this._mass = 10000;
            this._volume = 500000;
            this._material = "Wather";
            this._height = 1000;

            this._temperature = -10;
            this._currentCoord = new Coordinate(0, 0, 0);
            this._traveledDist = 0;
            this._statical = true;
        }

        
    }
}
