using MutationTestingPalindrome;

namespace MutationTestingPalindromeTests
{
    public class PalindromeTests
    {
        [Fact]
        public void WhenInputIsNotAPalindomeThenReject()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.Equal(0, palindromeTester.IsPalindrome("noos"));
        }

        [Fact]
        public void WhenInputLengthIsZeroThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.Equal(1, palindromeTester.IsPalindrome(""));
        }

        [Fact]
        public void WhenPalindromeOfTwoLettersThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.Equal(1, palindromeTester.IsPalindrome("oo"));
        }

        [Fact]
        public void WhenPalindromeOfFourLettersThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.Equal(2, palindromeTester.IsPalindrome("noon"));
        }

        [Fact]
        public void WhenPalindromeOfSixLettersThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.Equal(3, palindromeTester.IsPalindrome("snoons"));
        }
    }
}