using MutationTestingPalindrome;

namespace MutationTestingPalindromeTests
{
    public class PalindromeTests
    {
        [Fact]
        public void WhenInputLengthIsZeroThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.True(palindromeTester.IsPalindrome(""));
        }

        [Fact]
        public void WhenPalindromeThenAccept()
        {
            Palindrome palindromeTester = new Palindrome();

            Assert.True(palindromeTester.IsPalindrome("noon"));
        }
    }
}