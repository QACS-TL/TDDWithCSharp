namespace QLC1HighestNumberFinder
{
    public class HighestNumberFinder
    {
        public int FindHighestNumber(int[] values)
        {
            if (values.Length < 1)
                throw new ArgumentException("Array is empty");

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
