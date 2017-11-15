using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv2
{
    /// <summary>
    /// Нарушние наследования, когда базовый класс не полон или не имеет важной реализации,
    /// которая является общим для классов наследников. 
    /// </summary>
    public abstract class Car
    {
        private string _name;
        private uint _speed;

        public string Name { get => _name; }
        public uint CurrentSpeed { get => _speed; set => _speed = value; }
        public bool IsBroken { get; set; }

        public Car()
        {
            this._name = "NoName";
            this._speed = 0;
        }
        public Car(string name) : this()
        {
            this._name = name;
        }

        ///// <summary>
        ///// Ускорение.
        ///// </summary>
        ///// <param name="up"></param>
        //public abstract void SpeedUp(uint up);
        ///// <summary>
        ///// Замедление.
        ///// </summary>
        ///// <param name="slow"></param>
        //public abstract void SpeedDown(uint slow);

    }
    public class SportCar : Car
    {
        private uint _maxSpeed;
        private uint _minSpeed;

        public SportCar()
        {
            this._maxSpeed = 500;
            this._minSpeed = 0;
        }
        public SportCar(uint maxSpeed, uint minSpeed)
        {
            this._maxSpeed = maxSpeed;
            this._minSpeed = minSpeed;
        }

        /// <summary>
        /// Ускорение.
        /// </summary>
        /// <param name="up"></param>
        public void SpeedUp(uint up)
        {
            if (CurrentSpeed < _maxSpeed)
            {
                CurrentSpeed += up;
            }
            else IsBroken = true; // машина сломана
        }
        /// <summary>
        /// Замедление.
        /// </summary>
        /// <param name="slow"></param>
        public void SpeedDown(uint slow)
        {
            if (CurrentSpeed > _minSpeed)
            {
                CurrentSpeed -= slow;
            }
            else CurrentSpeed = 0; // останавливаемся
        }

        void Stop() // метод лучше вынести в базовый класс и переписать
        {
            CurrentSpeed = 0;
        }
    }
    public class CivilCar : Car
    {
        private uint _maxSpeed;
        private uint _minSpeed;

        public CivilCar()
        {
            this._maxSpeed = 250;
            this._minSpeed = 0;
        }
        public CivilCar(uint maxSpeed, uint minSpeed)
        {
            this._maxSpeed = maxSpeed;
            this._minSpeed = minSpeed;
        }

        /// <summary>
        /// Ускорение.
        /// </summary>
        /// <param name="up"></param>
        public void SpeedUp(uint up)
        {
            if (CurrentSpeed < _maxSpeed)
            {
                CurrentSpeed += up;
            }
            else IsBroken = true; // машина сломана
        }
        /// <summary>
        /// Замедление.
        /// </summary>
        /// <param name="slow"></param>
        public void SpeedDown(uint slow)
        {
            if (CurrentSpeed > _minSpeed)
            {
                CurrentSpeed -= slow;
            }
            else CurrentSpeed = 0; // останавливаемся
        }

        void Stop() // метод лучше вынести в базовый класс и переписать
        {
            CurrentSpeed = 0;
        }
    }
}
