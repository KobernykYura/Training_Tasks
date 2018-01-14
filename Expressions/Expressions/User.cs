using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    public class User
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; }
        public DateTime BirthDay { get; set; }

        public User()
        {
            this.FirstName = "User";
            this.LastName = "";
            this.BirthDay = DateTime.UtcNow;
            this.Age = (uint)DateTime.UtcNow.Year - (uint)BirthDay.Year;
        }
        public User(string first, string last, DateTime date)
        {
            this.FirstName = first;
            this.LastName = last;
            this.BirthDay = date.ToUniversalTime();
            this.Age= (uint)DateTime.UtcNow.Year - (uint)BirthDay.Year;
        }
    }
}
