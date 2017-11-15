using System;
using System.ComponentModel.DataAnnotations;
using Services.Common;
using Services.DataAccess;
using System.Text.RegularExpressions;

namespace Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Repository constructor.
        /// </summary>
        /// <param name="repository">Our connected repository. Must implement <see cref="IUserRepository"/>.</param>
        public UserService(IUserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Registration of new user.
        /// </summary>
        /// <param name="user">User for registration.</param>
        public void Register(User user)
        {
            //validation
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (string.IsNullOrEmpty(user.Login))
            {
                throw new ValidationException($"Incorrect login {user.Login}");
            }

            if (CheckUserByEmail(user.Email))
            {
                throw new ValidationException($"User with this email is currently exist {user.Email}");
            }

            if (GetUserByLogin(user.Login) != null)
            {
                throw new ValidationException($"User with this login is currently exist {user.Login}");
            }
            _repository.Create(user);
        }


        //---- get and check user methods

        /// <summary>
        /// Get user by id.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <returns>User that have this id.</returns>
        public User GetUser(int id)
        {
            User user = _repository.Get(id);
            if (user != null)
                return user;
            else throw new ArgumentNullException($"Empty user {user}");

        }

        /// <summary>
        /// Get user by login.
        /// </summary>
        /// <param name="login">Login of important user.</param>
        /// <returns>User with the same login.</returns>
        public User GetUserByLogin(string login)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            User user = _repository.GetUserByLogin(login);
            return user;
            
        }
        /// <summary>
        /// Check if user with the same email is exist.
        /// </summary>
        /// <param name="email">String of user's email.</param>
        /// <returns>Result if user with same email is exist.</returns>
        public bool CheckUserByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }

            if (!Regex.IsMatch(email, @"[a-z0-9]+[_a-z0-9\.-]*[a-z0-9]+@[a-z0-9-]+(\.[a-z0-9-]+)*(\.[a-z]{2,4})"))
            {
                throw new ArgumentException(nameof(email));
            }

            return _repository.CheckUserByEmail(email);
        }
        /// <summary>
        /// Check if user with this login <paramref name="login"/> and password <paramref name="password"/>.
        /// </summary>
        /// <param name="login">Login of user.</param>
        /// <param name="password">Password for login</param>
        /// <returns>If user with this login and password is exist.</returns>
        public bool Login(string login, string password)
        {
            if (string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }

            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }

            return _repository.LoginUser(login, password);
        }


        //---- unregister method

        /// <summary>
        /// Unregister user by id.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        public void Unregister(int id)
        {
            User user = _repository.Get(id);
            if (user != null)
                _repository.Delete(id);
            else throw new ArgumentNullException(nameof(user));
        }

    }
}
