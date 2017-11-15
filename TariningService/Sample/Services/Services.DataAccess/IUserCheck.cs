using Services.Common;

namespace Services
{
    /// <summary>
    /// CUID validation interface.
    /// </summary>
    public interface IUserCheck
    {
        /// <summary>
        /// Method of login user validation result.
        /// </summary>
        /// <param name="login">Login of user.</param>
        /// <param name="password">Password of user.</param>
        /// <returns>Bool result of users authentication.</returns>
        bool LoginUser(string login, string password);

        /// <summary>
        /// Verify user existence method.
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        bool CheckUserByEmail(string email);
    }
}