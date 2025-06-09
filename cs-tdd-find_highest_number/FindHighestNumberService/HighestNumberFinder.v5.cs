using System;

namespace FindHighestNumberService.v5
{
    public class HighestNumberFinder
    {
        public int findHighestNumber(int[] values)
        {
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
