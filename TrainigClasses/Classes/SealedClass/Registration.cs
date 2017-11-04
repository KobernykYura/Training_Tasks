using System;
using EncriptionCode;
using System.IO;
using System.Xml.Linq;

namespace SealedClass
{
    /// <summary>
    /// Abstract class of regicstration.
    /// </summary>
    public abstract class Registration
    {
        protected string _userName; // User's name
        protected string _password; // Password for user
        protected PermissionLevel _level; // User access level

        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public PermissionLevel Level { get => _level; set => _level = value; }

        // Enum of permission level of registered user.
        public enum PermissionLevel : byte
        {
            Root = 1,
            User,
            Reader
        }     

        public Registration()
        {
            UserName = "Guest";
            Level = PermissionLevel.Reader;
        }
        /// <summary>
        /// Constructor of registration as user with the name and password. Permititon level is <see cref="PermissionLevel.User"/>.
        /// </summary>
        /// <param name="name">Parameter of user's name. Type is <see cref="String"/>.</param>
        /// <param name="password">User's password. Type of parameter <see cref="String"/></param>
        public Registration(string name, string password)
        {
            UserName = name;
            Password = Encryption.Encode(password);
            Level = PermissionLevel.User;
        }
        /// <summary>
        /// Constructor for full registration.
        /// </summary>
        /// <param name="name">Register name of <see cref="String"/> type.</param>
        /// <param name="password">Regster password of <see cref="String"/> type.</param>
        /// <param name="level">Registration level of <see cref="PermissionLevel"/> enum type.</param>
        public Registration(string name, string password, PermissionLevel level) : this(name, password)
        {
            Level = level;
        }

        /// <summary>
        /// Method of saving user's account settings.
        /// </summary>
        public virtual void Save(string path)
        {
            if ((UserName != default(string) && UserName != "Guest") &&
                Password != default(string) && (Level != PermissionLevel.Reader && Level != 0))
            {
                using (FileStream stream = new FileStream(path, FileMode.OpenOrCreate))
                {
                    // Saving in XML file
                    XDocument xdoc = XDocument.Load(stream);
                    XElement root = xdoc.Element("Users");

                    root.Add(new XElement("User",
                    new XAttribute("Permition", this.Level),
                    new XElement("Name", this.UserName),
                    new XElement("Password", Encryption.Decode(this.Password))));
                    xdoc.Save(stream);
                }
            }
        }
        /// <summary>
        /// Method of cleaning user's account settings.
        /// </summary>
        public virtual void Clean()
        {
            if ((UserName != default(string) && UserName != "Guest") &&
                Password != default(string) && (Level != PermissionLevel.Reader && Level != 0))
            {
                // Set "clean" values
                UserName = "Guest";
                Level = PermissionLevel.Reader;
                Password = default(string);
            }
        }
    }
}