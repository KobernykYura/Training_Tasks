using Services.Common;
using System;

namespace Services.DataAccess
{
    /// <summary>
    /// СUID interface.
    /// </summary>
    public interface IUserRepository : IUserCheck
    {
        void Create(User user);

        User Get(int id);

        User GetUserByLogin(string login);

        void Update(User user);

        void Delete(int id);
    }
}