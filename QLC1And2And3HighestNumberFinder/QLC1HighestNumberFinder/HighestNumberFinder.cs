
namespace QLC1HighestNumberFinderService
{
    public class EmptyArrayException : Exception
    {
        public EmptyArrayException(string message) : base(message)
        {
        }
    }

    public class HighestNumberFinder: IHighestNumberFinder
    {
        public int FindHighestNumber(int[] values)
        {
            if (values.Length < 1)
                throw new EmptyArrayException("Array is empty");

            int result = Int32.MinValue;

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > result)
                    result = values[i];
            }
            return result;
        }
    }
}
