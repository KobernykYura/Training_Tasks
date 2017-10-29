using System;
using System.Collections.Generic;
using System.Text;

namespace SealedClass
{
    /// <summary>
    /// Sealed class of mail autorisation. 
    /// </summary>
    public sealed class MailRegistration : Registration
    {
        private string _smtpServer; // smtp - server of user
        private string _mailAddress; // sender address

        public string MailAddress { get => _mailAddress; set => _mailAddress = value; }
        public string SmtpServer { get => _smtpServer; set => _smtpServer = value; }

        /// <summary>
        /// Creating user of mail platform.
        /// </summary>
        /// <param name="name">User's name. Parameter <paramref name="name"/> of <see cref="String"/> type.</param>
        /// <param name="password">Password of account. Parameter <paramref name="password"/> of <see cref="String"/> type.</param>
        /// <param name="smtpServer">Smtp user's server address. Parameter <paramref name="smtpServer"/> of <see cref="String"/> type.</param>
        /// <param name="mailAddress">Address of sender. Parameter <paramref name="mailAddress"/> of <see cref="String"/> type.</param>
        public MailRegistration(string name, string password, string smtpServer, string mailAddress):base(name, password)
        {
            this.SmtpServer = smtpServer;
            this.MailAddress = mailAddress;
        }
    }
}
