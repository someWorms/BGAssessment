using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrome
{
    /// <summary>
    /// <c>String extensions</c> class to verify if string is palindrome
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// Default palindrome check, ignoring case, special characters, whitespaces.
        /// </summary>
        /// <param name="str">String to verify</param>
        /// <returns> <c>true</c> if palindrome, otherwise <c>false</c></returns>
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            if (str.Length == 1)
                return true;

            int leftPtr = 0;
            int rightPtr = str.Length - 1;

            while (leftPtr <= rightPtr)
            {
                if (!char.IsLetterOrDigit(str[leftPtr]))
                {
                    leftPtr++;
                    continue;
                }
                if (!char.IsLetterOrDigit(str[rightPtr]))
                {
                    rightPtr--;
                    continue;
                }

                if (char.ToLower(str[leftPtr]) != char.ToLower(str[rightPtr]))
                {
                    return false;
                }

                leftPtr++;
                rightPtr--;
            }

            return true;
        }
        /// <summary>
        /// Extended palindrome check, ignoring case, but sensetive to special characters and whitespaces.
        /// </summary>
        /// <param name="str">String to verify</param>
        /// <returns> <c>true</c> if palindrome, otherwise <c>false</c></returns>
        public static bool IsPalindromeSpecial(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;

            if (str.Length == 1)
                return true;

            int leftPtr = 0;
            int rightPtr = str.Length - 1;

            while (leftPtr <= rightPtr)
            {
                if (char.ToLower(str[leftPtr]) != char.ToLower(str[rightPtr]))
                {
                    return false;
                }

                leftPtr++;
                rightPtr--;
            }

            return true;
        }
    }
}
