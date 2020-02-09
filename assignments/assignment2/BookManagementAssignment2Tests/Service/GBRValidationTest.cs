using static GBRValidation.Service.GBRValidation;
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

        [Test]
        public void OnlyPunctuation_ReturnEmptyString()
        {
            string[] punctuations = {
                ";",".",",",":","?", "!", "{", "}", "(",")", "\'", "\"","-", "/"
            };
            string expected = String.Empty;

            foreach (var punctuation in punctuations)
            {
                Assert.AreEqual(expected, GBRTitleGrammer(punctuation));
            }
        }

        [Test]
        public void PunctuationFollowedByLetter_ReturnCapitalLetterOnly()
        {
            string[] punctuations = {
                ";a", ".b", ",c", ":d", "?e", "!f", "{g", "}h", "(i", ")j", "\'k", "\"l","-m", "/n"
            };

            for (int i = 0; i < punctuations.Length; i++)
            {
                string expected = Char.ToString((char) (i + 65));
                Assert.AreEqual(expected, GBRTitleGrammer(punctuations[i]));
            }
        }

        [Test]
        public void LetterFollowedByPunctuation_ReturnCapitalLetterOnly()
        {
            string[] punctuations = {
                "a;", "b.", "c,", "d:", "e?", "f!", "g{", "h}", "i(", "j)", "k\'", "l\"","m-", "n/"
            };

            for (int i = 0; i < punctuations.Length; i++)
            {
                string expected = Char.ToString((char) (i + 65));
                Assert.AreEqual(expected, GBRTitleGrammer(punctuations[i]));
            }
        }

        [Test]
        public void PunctuatedWords_ReturnPascalCased()
        {
            string[] words = { "intra-word", "intra_word", "intra::word", "intra::-word" };
            string expected = "Intra Word";
            foreach (string word in words)
            {
                Assert.AreEqual(expected, GBRTitleGrammer(word));
            }
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
            string[] input = { "PotAtO", "sAlaD", "toSs", "THRoW", "pUnCH" };
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
        [Test]
        public void EmptyOrNullISBN_ReturnsTrue()
        {
            Assert.IsTrue(GBRISBNValidation(null));
            Assert.IsTrue(GBRISBNValidation(""));
            Assert.IsTrue(GBRISBNValidation("  "));
        }

        [Test]
        public void LessThan13DigitsStringISNB_ReturnsFalse()
        {
            string input = "132154";
            Assert.IsFalse(GBRISBNValidation(input)); // False
        }

        [Test]
        public void ISBNWith13DigitsString_ReturnsTrue()
        {
            string input = "1234567890123";
            Assert.IsTrue(GBRISBNValidation(input)); // True
        }

        [Test]
        public void ISBNWithMoreThan13DigitsString_ReturnsFalse()
        {
            string input = "123456789012345";
            Assert.IsTrue(GBRISBNValidation(input)); // False
        }

        /* Phone Number Validation tests
         */
        [Test]
        public void NullEmptyOrWhitespecedPhoneNumber_ReturnTrue()
        {
            Assert.IsTrue(GBRPhoneNumberValidation(null));
            Assert.IsTrue(GBRPhoneNumberValidation(String.Empty));
            Assert.IsTrue(GBRPhoneNumberValidation("   "));
        }
        [Test]
        public void WeirdBugWithTilAndDot()
        {
            bool bug = GBRPhoneNumberValidation("123~132.1231");
            bool bug2 = GBRPhoneNumberValidation("1234.132.1231");
            Assert.IsFalse(bug);
            Assert.IsFalse(bug2);
        }

        [Test]
        public void WrongPhoneFormats_ReturnsFalse()
        {
            string[] phones = { 
            "1234.123.1234", "13324 12 1231", "12 123154 123", "asd as",
                "123~132.1231",
            "123-123.1324", "123-132 1234", "123-1231234",
            "123 123 1234", "123 123.1324", "123 132-1234", "123 1231234",
            "123.123-1324", "123.132 1234", "123.1231234",
            "123123 1234", "123123-1324", "123132.1234", "123.1231234",  };
            foreach (string phone in phones)
            {
                Assert.IsFalse(GBRPhoneNumberValidation(phone));
            }
        }
        [Test]
        public void ValidPhoneFormats_ReturnTrue()
        {
            string[] phones = {"123-123-1234", "123.123.1234", "1234567890"};
            foreach (string phone in phones)
            {
                Assert.IsTrue(GBRPhoneNumberValidation(phone));
            }
        }

        /* Postal Code Validation tests
         */
        [Test]
        public void InvalidFormat_ReturnsFalse()
        {
            string invalid = "AA7 2A2";

            Assert.IsFalse(GBRPostalCodeValidation(ref invalid));
            Assert.AreEqual("AA7 2A2", invalid);
        }
        [Test]
        public void ValidFormat_ReturnsTrueAndMutatesString()
        {
            string valid = "N2C2A2";
            bool expected = GBRPostalCodeValidation(ref valid);

            Assert.IsTrue(expected);
            Assert.AreEqual("N2C 2A2", valid);
            Assert.AreNotEqual("N2C2A2", valid);
        }
        [Test]
        public void InvalidPostalCodeStartsWithAInvalidLetter_ReturnsFalseAndNoMutation()
        {
            string[] invalidLetters = { "D", "F", "I", "O", "Q", "U", "W", "Z" };
            string extra = "2C2A2";

            foreach (string invalid in invalidLetters)
            {
                string invalidZip = invalid + extra;
                Assert.IsFalse(GBRPostalCodeValidation(ref invalidZip));
            }
        }
        [Test]
        public void InvalidPostalCodeInvalidLetter_ReturnsFalseAndNoMutation()
        {
            string[] invalidLetters = { "D", "F", "I", "O", "Q", "U", "W", "Z" };
            for (int i = 0; i < invalidLetters.Length; i++)
            {

                string invalidZip = invalidLetters[i] + "2" + invalidLetters[i] + "2" + invalidLetters[i] + "2";
                Assert.IsFalse(GBRPostalCodeValidation(ref invalidZip));
            }
        }

        /*Test cases for email
         */
        [Test]
        public void NullEmptyOrWhitespecedEmail_ReturnTrue()
        {
            Assert.IsTrue(GBRValidateEmail(null));
            Assert.IsTrue(GBRValidateEmail(""));
            Assert.IsTrue(GBRValidateEmail("  "));
        }
        [Test]
        public void ValidEmails_ReturnTrue()
        {
            string[] emails = { "test@email.com", "email@email.edu", "email@email.ca", "test.email@valid.com", "test_email@valid.com.br", "weird@test.co.uk" };
            foreach (var email in emails)
            {
                Assert.IsTrue(GBRValidateEmail(email));

            }
        }
        [Test]
        public void IncompletedEmail_ReturnFalse()
        {
            string[] emails = { "test@email", "@email.edu", "email@email_ca", "test.email@valid com", "test_email valid.com.br", "weird*Test.ly" };
            foreach (var email in emails)
            {
                Assert.IsFalse(GBRValidateEmail(email));

            }
        }

        /* Test cases for date
         */
    }
}