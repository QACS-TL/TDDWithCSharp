
namespace MutationTestingPalindrome
{
    public class Palindrome
    {
        public bool IsPalindrome(String inputString)
        {
            bool result = false;

            if (inputString.Count() == 0)
            {
                result = true;
            }
            else
            {
                char firstChar = inputString[0];
                char lastChar = inputString[inputString.Count() - 1];
                String mid = inputString.Substring(1, inputString.Count() - 2);
                result = (firstChar == lastChar) && IsPalindrome(mid);
            }
            return result;

        }
    }
}
