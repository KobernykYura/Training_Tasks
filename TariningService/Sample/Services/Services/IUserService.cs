using Services.Common;

namespace Services
{
    /// <summary>
    /// Service interface.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Registration methods.
        /// </summary>
        /// <param name="user">User of type <see cref="User"/> for registration.</param>
        void Register(User user);

        /// <summary>
        /// Logging method.
        /// </summary>
        /// <param name="login">login of user.</param>
        /// <param name="password">password of user.</param>
        /// <returns></returns>
        bool Login(string login, string password);

        /// <summary>
        /// Get user by id method.
        /// </summary>
        /// <param name="id">Id of user.</param>
        /// <returns>User by id.</returns>
        User GetUser(int id);

        /// <summary>
        /// Get user by login.
        /// </summary>
        /// <param name="login">login of user.</param>
        /// <returns>user by login.</returns>
        User GetUserByLogin(string login);

        /// <summary>
        /// Method of unregistration user by id.
        /// </summary>
        /// <param name="id">id of the remote user.</param>
        void Unregister(int id);

    }
}