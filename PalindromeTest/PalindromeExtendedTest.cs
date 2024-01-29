namespace PalindromeTest
{
    [TestClass]
    public class PalindromeExtendedTest
    {
        /// <summary>
        /// Word ignoring case and case sensetive tests
        /// </summary>
        /// <param name="value"></param>

        #region Word

        [TestMethod]
        [DataRow("m")]
        [DataRow("mm")]
        [DataRow("asdsa")]
        [DataRow("asddsa")]
        [DataRow("deleveled")]
        public void IsPalindrome_Word_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is a palindrome, but return false");
        }

        [TestMethod]
        [DataRow("mM")]
        [DataRow("asdSA")]
        [DataRow("ASDdsa")]
        [DataRow("DeleVeled")]
        [DataRow("DeleVeleD")]
        public void IsPalindrome_CaseSensetiveWord_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is palindrome, but return false");
        }

        [TestMethod]
        [DataRow("qp")]
        [DataRow("asda")]
        [DataRow("depqed")]
        [DataRow("deployed")]
        public void IsPalindrome_Word_ReturnFalse(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsFalse(result, $"{value} is not a palindrome, but return true");
        }

        #endregion


        /// <summary>
        /// Digit tests
        /// </summary>
        /// <param name="value"></param>

        #region Digit

        [TestMethod]
        [DataRow("123321")]
        [DataRow("12321")]
        [DataRow("909090090909")]
        [DataRow("10000001")]
        [DataRow("55")]
        [DataRow("8")]
        public void IsPalindrome_Digit_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is palindrome, but return false");
        }


        [TestMethod]
        [DataRow("123221")]
        [DataRow("126121")]
        [DataRow("0101")]
        [DataRow("001")]
        [DataRow("10293874")]
        [DataRow("1011")]
        [DataRow("1101")]
        [DataRow("11011101")]
        public void IsPalindrome_Digit_ReturnFalse(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsFalse(result, $"{value} is not palindrome, but return true");
        }

        #endregion


        /// <summary>
        /// Alphanumeric ignoring case and case sensitive tests 
        /// </summary>
        /// <param name="value">Data to pass</param>
        
        #region Alphanumeric

        [TestMethod]
        [DataRow("0sds0")]
        [DataRow("1sdds1")]
        [DataRow("del161led")]
        [DataRow("de13v31ed")]
        public void IsPalindrome_Alphanumeric_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is palindrome, but return false");
        }

        [TestMethod]
        [DataRow("0sdS0")]
        [DataRow("1SDds1")]
        [DataRow("Del161led")]
        [DataRow("De13V31eD")]
        public void IsPalindrome_AlphanumericCaseSensetive_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is palindrome, but return false");
        }

        [TestMethod]
        [DataRow("0sdS1")]
        [DataRow("1SDdsk")]
        [DataRow("Del161l3d")]
        [DataRow("ed13V31eD")]
        public void IsPalindrome_Alphanumeric_ReturnFalse(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsFalse(result, $"{value} is not a palindrome, but return true");
        }

        #endregion

        /// <summary>
        /// Test case include mix of alphanumerics with special characters includig spaces
        /// </summary>
        /// <param name="value"></param>
        
        #region Specials

        [TestMethod]
        [DataRow("....")]
        [DataRow("..@..")]
        [DataRow(",. @ .,")]
        [DataRow("# A a #")]
        [DataRow("\';1 p p 1;\'")]
        [DataRow("/k/")]
        [DataRow("\\nn\\")]
        [DataRow("  ")] //two spaces
        [DataRow(" ")] //one space
        [DataRow("龙龙")] //unicode 
        [DataRow("@龙 龙@")] //unicode 
        [DataRow("\u20A9 iSi \u20A9")]
        public void IsPalindrome_Specials_Should(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsTrue(result, $"{value} is palindrome, but return false");
        }

        #endregion

        /// <summary>
        /// Test cases dedicated to chech of handling worng data passed.
        /// </summary>
        /// <param name="value"></param>
        
        #region Null

        [TestMethod]
        [DataRow(null)]
        [DataRow("")]
        [DataRow("A man, a plan, a canal: Panama!")] // IS NOT A PALINDROME AS WE ARE NOT IGNORING WHITESPACES, NOR SPECIALS
        public void IsPalindrome_Null_ReturnFalse(string value)
        {
            var result = value.IsPalindromeSpecial();

            Assert.IsFalse(result, $"{value} must not be evaluated as palindrome, but return true");
        }

        #endregion
    }
}