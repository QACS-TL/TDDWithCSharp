
namespace MutationTestingPalindrome
{
    public class Palindrome
    {
        private class Result
        {
            internal String InputString { get; set; }
            internal int Count { get; set; } = 0;

            public Result(String inputString, int initCount)
            {
                this.InputString = inputString;
                Count = initCount;
            }
        }

        private class Tokens
        {
            internal char FirstChar { get; private set; }
            internal char LastChar { get; private set; }
            internal String Mid { get; private set; }

            public void GrabData(String inputString)
            {
                FirstChar = inputString[0];
                LastChar = inputString[inputString.Count() - 1];
                Mid = inputString.Substring(1, inputString.Count() - 2);
            }
        }

        private Tokens grabbedTokens = new Tokens();

        public int IsPalindrome(String inputString)
        {
            int result = 0;

            if (inputString.Count() == 0)
            {
                result = 1;
            }
            else
            {
                grabbedTokens.GrabData(inputString);
                if (grabbedTokens.FirstChar == grabbedTokens.LastChar)
                {
                    Result tempResult = new Result(grabbedTokens.Mid, 1);
                    IsPalindrome(tempResult);
                    result = tempResult.Count;
                }
            }
            return result;
        }

        private void IsPalindrome(Result inputValues)
        {
            if (inputValues.InputString.Count() > 0)
            {
                grabbedTokens.GrabData(inputValues.InputString);
                if (grabbedTokens.FirstChar == grabbedTokens.LastChar)
                {
                    inputValues.Count++;
                    inputValues.InputString = grabbedTokens.Mid;
                    IsPalindrome(inputValues);
                }
            }
        }
    }
}
