using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv1
{
    /// <summary>
    /// Нарушается полиморфизм, когда реализация интерфейса пуста, но метод доступен.
    /// </summary>
    public class Person : IWork, IRelax
    {
        private string _name;
        private byte _tired;

        public string Name { get => _name; set => _name = value; }
        public string Company { get; set; }

        public Person(string name)
        {
            this._name = name;
            this._tired = 0;
        }

        /// <summary>
        /// Person is working.
        /// </summary>
        public void WorkHard()
        {
            if (_tired < 220)
            {
                _tired += 5;
            }
            else RelaxWhile(_tired);
        }
        /// <summary>
        /// If person is tired.
        /// </summary>
        /// <returns></returns>
        public bool IsTired()
        {
            byte t = byte.MaxValue - 95;
            return _tired >= t ? true : false;
        }

        /// <summary>
        /// Person is relax.
        /// </summary>
        /// <param name="time"></param>
        public void RelaxWhile(uint time) // плохо оставлять пустым раелизуемый метод интерфейса.
        {
            throw new NotImplementedException();
        }

    }
}
