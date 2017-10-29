using System;
using CloudAbstractCloud.Interfaces;

namespace CloudAbstractCloud
{
    public class Cloud : AbstractCloud, IRainable, IMoveable
    {
        public string Type { get => _type; set => _type = value; }
        public ulong Mass { get => _mass; set => _mass = value; }
        public ulong Volume { get => _volume; set => _volume = value; }
        public string Material { get => _material; set => _material = value; }
        public uint Hight { get => _height; set => _height = value; }

        public Coordinate PreviousCoord { get => _previousCoord; set => _previousCoord = value; }
        public Coordinate CurrentCoord { get => _currentCoord; set => _currentCoord = value; }

        public short Temperature { get => _temperature; set => _temperature = value; }
        public bool Statical { get => _statical; }

        /// <summary>
        /// Создание облака с настроенными значениями.
        /// </summary>
        /// <param name="type">Название типа облака типа <see cref=" System.String"/>.</param>
        /// <param name="mass">Масса облака типа <see cref="System.UInt32"/>.</param>
        /// <param name="volume">Объем облака типа <see cref="uint"/>.</param>
        /// <param name="material">Вещество облака.</param>
        /// <param name="hight">Высота облака.</param>
        /// <param name="direction">Направление движения облака.</param>
        /// <param name="coordinate">Текущие координаты облакаю</param>
        /// <param name="distanse">пройденная дистанция.</param>
        public Cloud(string type, uint mass, uint volume, string material, uint hight, sbyte temperature,
            Direction direction = null, Coordinate coordinate = null)
        {
            this._type = type;
            this._mass = mass;
            this._volume = volume;
            this._material = material;
            this._height = hight;

            this._temperature = temperature;

            this._direction = direction;
            this._currentCoord = coordinate;
            this._statical = true;
        }

        /// <summary>
        /// Метод моделирования дождя
        /// </summary>
        /// <param name="minuts">Продолжительность осадков.</param>
        public void ItsRaining(uint minuts)
        {
            if (Temperature >= RAIN_SNOW_TEMPERATURE) //----Проверка температуры
            {
                for (int i = 0; i < minuts; i++)    //----Цикл выпадения осадков
                {
                    if (Mass - RAIN_MASS > 0)       //----Проверка возмодности выпадения осадков
                    {
                        Mass -= RAIN_MASS;
                        Volume -= RAIN_VOLUME;
                    }
                    else throw new Exception("Дождь закончился, облако достигло минимальных размеров.");
                }
            }
            else throw new Exception("При установленной температуре выпадение дождевых осадков не возможно. ");

        }
        /// <summary>
        /// Метод моделирования снегопада.
        /// </summary>
        /// <param name="minuts">Продолжительность осадков.</param>
        public void ItsSnowing(uint minuts)
        {
            if (Temperature <= RAIN_SNOW_TEMPERATURE && Temperature >= SNOW_HAIL_TEMPERATURE)   //----Проверка температуры
            {
                for (int i = 0; i < minuts; i++)    //----Цикл выпадения осадков
                {
                    if (Mass - SNOW_MASS > 0)   //----Проверка возмодности выпадения осадков
                    {
                        Mass -= SNOW_MASS;
                        Volume -= SNOW_VOLUME;
                    }
                    else throw new Exception("Дождь закончился, облако достигло минимальных размеров.");
                }
            }
            else throw new Exception("При установленной температуре выпадение снежных осадков не возможно. ");
        }
        /// <summary>
        /// Метод моделирования града.
        /// </summary>
        /// <param name="minuts">Продолжительность осадков.</param>
        public void ItsHailing(uint minuts)
        {
            if (Temperature <= SNOW_HAIL_TEMPERATURE)    //----Проверка температуры
            {
                for (int i = 0; i < minuts; i++)    //----Цикл выпадения осадков
                {
                    if (Mass - HAIL_MASS > 0)       //----Проверка возмодности выпадения осадков
                    {
                        Mass -= HAIL_MASS;
                        Volume -= HAIL_VOLUME;
                    }
                    else throw new Exception("Дождь закончился, облако достигло минимальных размеров.");
                }
            }
            else throw new Exception("При установленной температуре выпадение градовых осадков не возможно. ");
        }
        /// <summary>
        /// Перемещение облака в направлении <paramref name="direction"/>.
        /// </summary>
        /// <param name="direction">Направление перемещения облака.</param>
        public void MoveCloud(Direction direction)
        {
            if (direction != null)
            {
                //----Настоящая коррдината стала прошлой.
                _previousCoord = _currentCoord;

                //----Новое направление облака.
                this._direction = direction;

                //----Изменение координат.
                var res = direction.Ordinate * direction.Abscissa;
                CurrentCoord.Gradus += res;
                CurrentCoord.Minuts += res;
                CurrentCoord.Seconds += res;
            }
        }
        /// <summary>
        /// Метод предсказания следующей координаты облака.
        /// </summary>
        /// <returns>Предполагаемую координату облака.</returns>
        public Coordinate FutureCoordinate()
        {
            var grad = CurrentCoord.Gradus + _direction.Ordinate * _direction.Abscissa;     //----Изменение координат
            var min = CurrentCoord.Minuts + _direction.Ordinate * _direction.Abscissa;
            var sec = CurrentCoord.Seconds + _direction.Ordinate * _direction.Abscissa;

            return new Coordinate(grad, min, sec); 
        }
        /// <summary>
        /// Увеличение массы облака.
        /// </summary>
        /// <param name="volume">Добавляемый объем.</param>
        /// <param name="mass">Добавляемая масса.</param>
        public void IncreaseMass(uint volume, uint mass)
        {
            if (!(Volume + volume > CRITICAL_VOLUME) && !(Mass + mass > CRITICAL_MASS))
            {
                _mass += mass;
                _volume += volume;
            }
            else throw new Exception("Превышено критическая масса облака! Введите другие значения.");
        }
        /// <summary>
        /// Метод определения, двигалось ли облако.
        /// </summary>
        /// <returns>Результат сравления настоящих и предидущих координат.</returns>
        public bool IsMove()
        {
            return _currentCoord != _previousCoord;
        }
        /// <summary>
        /// Вычисление пройденного расстояния облаком.
        /// </summary>
        /// <returns></returns>
        public double DistanceTraveled()
        {
            return PreviousCoord.Gradus - CurrentCoord.Gradus;
        }
    }
}
