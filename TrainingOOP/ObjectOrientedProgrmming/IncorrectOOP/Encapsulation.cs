using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncorrectOOPv1
{
    /// <summary>
    /// Нет инкапсуляции данных. Пароль можно свободно изменить.
    /// Правильное решение проблемы - оставить установку пароля только в конструкторе. 
    /// </summary>
    public class User
    {
        private string _login;
        private string _password;

        /// <summary>
        /// Логин и пароль пользователя лучше устанавливать через конструктор, чем предоставлять
        /// публичгый set; Иначе есть вероятность, что целостность даных будет нарушена.
        /// </summary>
        public string Login { get => _login; set => _login = value; }
        public string Password { get => _password; set => _password = value; }

        /// <summary>
        /// Конструктор для инициализации логина и пароля. 
        /// Сохраняет целостность данных для этого объекта.
        /// </summary>
        /// <param name="login">Логин.</param>
        /// <param name="password">Пароль.</param>
        public User(string login, string password)
        {
            this._login = login;
            this._password = password;
        }
    }
    
}
