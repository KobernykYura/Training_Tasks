using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Expressions
{
    public static class CreateExpression
    {
        /// <summary>
        /// Present in the form of an Expression expression the code that creates an instance of the User object from the previous job and assigns the Name, Surname, Birth date and Age of the input arguments:
        /// the delegate has something like the following: Func<string, string, DateTime, User> a, b, c=> new User {FisrtName = a, LastName = b, BirthDay = c};
        /// </summary>
        /// <param name="name"></param>
        /// <param name="secoundName"></param>
        /// <param name="dateOfBirth"></param>
        /// <returns></returns>
        public static User GetUser(string name, string secoundName, DateTime dateOfBirth)
        {
            var createdType = typeof(User);

            var firstName = Expression.Parameter(typeof(string), "first");
            var lastName = Expression.Parameter(typeof(string), "last");
            var dateBirth = Expression.Parameter(typeof(DateTime), "date");

            int count = createdType.GetConstructors().Length;
            var crot = Expression.New(createdType.GetConstructors()[count - 1],firstName,lastName,dateBirth);

            var propertyFirstName = createdType.GetProperty("FirstName");
            var propertyLastName = createdType.GetProperty("LastName");
            var propertyBirthDay = createdType.GetProperty("BirthDay");

            var bindFirst = Expression.Bind(propertyFirstName, firstName);
            var bindLast = Expression.Bind(propertyLastName, lastName);
            var bindDateBirth = Expression.Bind(propertyBirthDay, dateBirth);

            var memberInit = Expression.MemberInit(crot, bindFirst, bindLast, bindDateBirth);

            Expression<Func<string, string, DateTime, User>> member = Expression.Lambda<Func<string, string, DateTime, User>>(memberInit, firstName, lastName, dateBirth);

            return member.Compile()(name, secoundName, dateOfBirth);
        }

        /// <summary>
        /// Present in the form of an Expression expression the code that creates an instance of the User object from the previous job and assigns the Name and Surname of the input arguments:
        /// the delegate has something like the following: Func<string, string, User> a, b => new User {FisrtName = a, LastName = b};
        /// </summary>
        /// <param name="name"></param>
        /// <param name="secoundName"></param>
        /// <returns></returns>
        public static User GetUser(string name, string secoundName)
            {
                var createdType = typeof(User);

                var firstName = Expression.Parameter(typeof(string), "first");
                var lastName = Expression.Parameter(typeof(string), "last");

                var crot = Expression.New(createdType);

                var propertyFirstName = createdType.GetProperty("FirstName");
                var propertyLastName = createdType.GetProperty("LastName");

                var bindFirst = Expression.Bind(propertyFirstName, firstName);
                var bindLast = Expression.Bind(propertyLastName, lastName);

                var memberInit = Expression.MemberInit(crot, bindFirst, bindLast);

                Expression<Func<string, string, User>> member = Expression.Lambda<Func<string, string, User>>(memberInit, firstName, lastName);

                return member.Compile()(name, secoundName);
            }

        /// <summary>
        /// Create with the help of Expression a delegate of the form: (x, y) => (x - y) / 2
        /// </summary>
        /// <returns></returns>
        public static Func<double, double, double> TaskForAllExpression()
        {
            var x = Expression.Parameter(typeof(double), "x");
            var y = Expression.Parameter(typeof(double), "y");
            var con = Expression.Constant(2.0);

            var sub = Expression.Subtract(x, y);
            var div = Expression.Divide(sub, con);

            var lambda = Expression.Lambda<Func<double, double, double>>(div, x, y);

            return lambda.Compile();
        }
    }
}
