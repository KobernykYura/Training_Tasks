using System;

namespace SealedClass
{
    /// <summary>
    /// Sealed class of site autorisation. 
    /// </summary>
    public sealed class SiteRegistration : Registration
    {
        private string _mailAddress; // user's mail address
        private string _accountName; // account name
        private SocialNetwork _network; // user's network

        public string MailAddress { get => _mailAddress; set => _mailAddress = value; }
        public string AccountName { get => _accountName; set => _accountName = value; }
        public SocialNetwork Network { get => _network; set => _network = value; }

        // Enum of user's socialnetwork
        public enum SocialNetwork
        {
            FaceBook = 1,
            Twitter ,
            GooglePlus,
            LinkedIn,
            Vk, 
            Yangex
        }

        /// <summary>
        /// Constructor of default registration.
        /// </summary>
        public SiteRegistration() : base()
        {
            this.AccountName = "Guest";
            this.MailAddress = "guest@mail.by";
        }
        /// <summary>
        /// Constructor of reistration 
        /// </summary>
        /// <param name="name">Parameter <paramref name="name"/> of <see cref="String"/> type.</param>
        /// <param name="password">Parameter <paramref name="password"/> of <see cref="String"/> type.</param>
        /// <param name="accName">Parameter <paramref name="accName"/> of <see cref="String"/> type.</param>
        /// <param name="mailAddress">Parameter <paramref name="mailAddress"/> of <see cref="String"/> type.</param>
        public SiteRegistration(string name, string password, string accName, string mailAddress) : base(name, password)
        {
            this.MailAddress = mailAddress;
            this.AccountName = accName;
        }
        /// <summary>
        /// Construcror of registration with social networks.
        /// </summary>
        /// <param name="name">Parameter <paramref name="name"/> of <see cref="String"/> type.</param>
        /// <param name="password">Parameter <paramref name="password"/> of <see cref="String"/> type.</param>
        /// <param name="accName">Parameter <paramref name="accName"/> of <see cref="String"/> type.</param>
        /// <param name="mailAddress">Parameter <paramref name="mailAddress"/> of <see cref="String"/> type.</param>
        /// <param name="network">Parameter <paramref name="network"/> of <see cref="String"/> type.</param>
        public SiteRegistration(string name, string password, string accName, string mailAddress, SocialNetwork network) : this(name, password, accName, mailAddress)
        {
            this.Network = network;
        }
        /// <summary>
        /// Constructor of registration with setting permition level.
        /// </summary>
        /// <param name="name">User's name. Parameter <paramref name="name"/> of <see cref="String"/> type.</param>
        /// <param name="password">Password of account. Parameter <paramref name="password"/> of <see cref="String"/> type.</param>
        /// <param name="accName">Name of user's account. Parameter <paramref name="accName"/> of <see cref="String"/> type.</param>
        /// <param name="mailAddress">Mail address. Parameter <paramref name="mailAddress"/> of <see cref="String"/> type.</param>
        /// <param name="level">Level permition. Parameter <paramref name="level"/> of <see cref="String"/> type.</param>
        public SiteRegistration(string name, string password, string accName, string mailAddress, PermissionLevel level) : base(name, password, level)
        {
            this.MailAddress = mailAddress;
            this.AccountName = accName;
            this.Level = level;
        }


    }
}
