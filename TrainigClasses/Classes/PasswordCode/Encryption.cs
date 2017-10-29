using System;

namespace PasswordCode
{
    /// <summary>
    /// Class for encode and decode of <see cref="string"/> line. 
    /// </summary>
    public static class Encryption
    {
        /// <summary>
        /// Encode line in new format.
        /// </summary>
        /// <param name="line">Line for encryption.</param>
        /// <returns>Encrypted line.</returns>
        public static string Encode(string line)
        {
            string enCode = default(string);
            
            // Change every char in string line.
            foreach (char a in line)
            {
                char ch = a;
                ch--;
                enCode += ch;
            }
            return enCode;
        }
        /// <summary>
        /// Decode a previously encoded string line.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        public static string Decode(string line)
        {
            string deCode = default(string);

            // Change every char in string line.
            foreach (char a in line)
            {
                char ch = a;
                ch++;
                deCode += ch;
            }
            return deCode;
        }
    }
}
