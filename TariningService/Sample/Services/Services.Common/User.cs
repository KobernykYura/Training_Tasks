using System;

namespace Services.Common
{
    /// <summary>
    /// Class of service user.
    /// </summary>
    public class User
    {

        public string Login { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

    }
}
