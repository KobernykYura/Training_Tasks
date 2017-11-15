using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv2
{
    /// <summary>
    /// Плохо, если мы забываем переопределить важный метод из базового класса для дочернего.
    /// </summary>
    class Polymorphism
    {
        public abstract class Car
        {
            private string _name;
            private uint _speed;

            private const uint MAX_SPEED = 250;
            private const uint MIN_SPEED = 0;

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

            /// <summary>
            /// Ускорение.
            /// </summary>
            /// <param name="up"></param>
            public virtual void SpeedUp(uint up)
            {
                if (IsBroken)
                {
                    throw new Exception("We can't increase speed more. Our car is broken.");
                }

                if (CurrentSpeed < MAX_SPEED)
                {
                    CurrentSpeed += up;
                }
                else IsBroken = true; // машина сломана
            }
            /// <summary>
            /// Замедление.
            /// </summary>
            /// <param name="slow"></param>
            public virtual void SpeedDown(uint slow)
            {
                if (CurrentSpeed > MIN_SPEED)
                {
                    CurrentSpeed -= slow;
                }
                else CurrentSpeed = 0; // останавливаемся
            }
            /// <summary>
            /// Остановка.
            /// </summary>
            /// <param name="slow"></param>
            public void Stop() // метод лучше вынести в базовый класс и переписать
            {
                CurrentSpeed = 0;
            }

        }
        /// <summary>
        /// У спорткара максимальная скорость намного выше стандартного автомобиля,
        /// надо переопределить поведение увеличения скорости.
        /// </summary>
        public class SportCar : Car
        {
            private uint _maxSpeed;
            private uint _minSpeed;

            public SportCar(string name) : base(name)
            {
                this._maxSpeed = 500;
                this._minSpeed = 0;
            }
            public SportCar(string name, uint maxSpeed, uint minSpeed) : this(name)
            {
                this._maxSpeed = maxSpeed;
                this._minSpeed = minSpeed;
            }

        }
        /// <summary>
        /// Виртуальные методы переопределены для гражданского автомобиля.
        /// </summary>
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
            public override void SpeedUp(uint up)
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
            public override void SpeedDown(uint slow)
            {
                if (CurrentSpeed > _minSpeed)
                {
                    CurrentSpeed -= slow;
                }
                else CurrentSpeed = 0; // останавливаемся
            }

        }
    }
}
