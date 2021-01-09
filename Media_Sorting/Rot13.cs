using System;
/// <summary>
/// Author: Mingi Kang
/// 
/// File Date: 10/31/2020
/// 
/// Purpose of the Class: Apply the Rot13 algorithm that
/// shifts all the letters by 13 and use it to decrypt
/// the summary of movies and books
/// 
/// Citation: NA, NA.(2020). C# ROT13 Method. Retrived from https://thedeveloperblog.com/rot13
/// reference used for sorting: https://thedeveloperblog.com/rot13
/// </summary>
namespace Media_Sorting
{
    /// <summary>
    /// Inherting from the IEncryptable to ensure
    /// the data is encryptable
    /// </summary>
    class Rot13 : IEncryptable
    {
        private String summary; // Summary of either movie or a book object

        /// <summary>
        /// Creating the decrypted version of the summary
        /// </summary>
        /// <param name="summary"></param>
        public Rot13(String summary)
        {
            this.summary = summary; // Set the summary to new summary
        }

        /// <summary>
        /// Used to encrypt a given string
        /// </summary>
        /// <returns>Encrypted version of the string</returns>
        public String Encrypt()
        {
            char[] word = summary.ToCharArray(); // Store the string as individual characters
            for (int i = 0; i < word.Length; i++) // Until the end of string
            {
                int index = (int)word[i]; // Index of the alphabet

                if (index >= 'a' && index <= 'z') // If the index of the string is an alphabet
                {
                    if (index > 'm') // If the alphabet is greater than m rotate 13 space backwards
                    {
                        index -= 13;
                    }
                    else // If the alphabet is less than m rotate 13 space backwards
                    {
                        index += 13;
                    }
                }
                else if (index >= 'A' && index <= 'Z') // Using capital letters
                {
                    if (index > 'M')
                    {
                        index -= 13;
                    }
                    else
                    {
                        index += 13;
                    }
                }
                word[i] = (char)index; // Store the individual letters back to string
            }
            return new string(word); // Return the encrypted string
        }

        /// <summary>
        /// Same algorithm applies for decrypting
        /// </summary>
        /// <returns>Return the decrypted version of the string</returns>
        public String Decrypt()
        {
            return Encrypt();
        }

        /// <summary>
        /// Return the encryted or decrypted string
        /// </summary>
        /// <returns>Encrypted value of the string was not encrypted and reverse otherwise</returns>
        public override String ToString()
        {
            return Encrypt();
        }
    }
}
