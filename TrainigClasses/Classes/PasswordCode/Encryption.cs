using System;

namespace EncriptionCode
{
    /// <summary>
    /// Class for encode and decode of <see cref="string"/> line. 
    /// </summary>
    public static class Encryption
    {

        /// <summary>
        /// Encode line in new format.
        /// </summary>
        /// <param name="line">Line for encoding.</param>
        /// <returns>Encoded value of <see cref="String"/> type.</returns>
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
        /// <param name="line">Line for decoding</param>
        /// <returns>Decoded value of <see cref="String"/> type.</returns>
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
