using static BookManagementAssignment2.Service.GBRValidation;
using NUnit.Framework;
using System;

namespace BookManagementAssignment2Tests
{
    public class Tests
    {
        /* Title Grammer tests
         */
        /* Empty input returns Empty String.
        */
        [Test]
        public void NullInput_ReturnsEmptyString()
        {
            string input = null;
            string expected = String.Empty;

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void EmptyInput_ReturnsEmptyString()
        {
            string input = String.Empty;
            string expected = String.Empty;

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void WhitespacedInput_ReturnEmptyString()
        {
            string input = "     ";
            string expected = String.Empty;

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
            Assert.Zero(actual.Length);
        }

        /* Test Whitespeace leading input
         */
        [Test]
        public void WhitespaceBeforeString_ReturnStringWithoutLeadingWhitespace()
        {
            string input = " input test";
            string expected = "Input Test";

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected[0], actual[0]);
            Assert.AreNotEqual(input[0], actual[0]);
        }

        [Test]
        public void WhitespaceAfterText_ReturnStringWithouTrailingWhitespace()
        {
            string input = "input text ";
            string expected = "Input Text";

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected[expected.Length - 1], actual[actual.Length - 1]);
            Assert.AreNotEqual(input, actual);
            Assert.AreNotEqual(input[input.Length - 1], actual[actual.Length - 1]);
        }

        [Test]
        public void LowerCaseWord_ReturnsPascalCasedWord()
        {
            string input = "camel Case";
            string expected = "Camel Case";

            string actual = GBRTitleGrammer(input);

            Assert.AreEqual(expected, actual);
            Assert.AreNotEqual(input, actual);
        }

        [Test]
        public void RandomCaseWords_ReturnsPascalCasedWord()
        {
            string[] input = {"PotAtO", "sAlaD","toSs", "THRoW", "pUnCH" };
            string[] expected = { "Potato", "Salad", "Toss", "Throw", "Punch" };

            for (int i = 0; i < input.Length; i++)
            {
                string actual = GBRTitleGrammer(input[i]);
                Assert.AreEqual(expected[i], actual);
                Assert.AreNotEqual(input[i], actual);
            }
        }

        /* ISBN Validation tests
         */

        /* Phone Number Validation tests
         */

        /* Postal Code Validation tests
         */
    }
}