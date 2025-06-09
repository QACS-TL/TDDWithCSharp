using System;

namespace FindHighestNumberService.v4
{
    public class HighestNumberFinder
    {
        public int findHighestNumber(int[] values)
        {
            int result = values[0];

            if (values.Length > 1 && values[1] > result)
                result = values[1];

            return result;
        }
    }
}
