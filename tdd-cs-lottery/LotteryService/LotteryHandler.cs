using LotteryService;
using System.Collections.Generic;

namespace tdd_cs_lotterytickets
{
    public class LotteryHandler
    {
        private INumberGenerator generator;
        public const int LOTTERY_SIZE = 5;
        public const int HIGHEST_NUMBER = 99;


        public LotteryHandler(INumberGenerator generator)
        {
            this.generator = generator;
        }

        public HashSet<int> GenerateRandomSet()
        {
            HashSet<int> result = new ();

            while (result.Count < LOTTERY_SIZE)
            {
                int num = generator.generate(HIGHEST_NUMBER);
                result.Add(num + 1);
            }

            return result;
        }

        public string format(HashSet<int> numbers)
        {
            string result = "";
            int count = 0;

            foreach (int num in numbers)
            {
                //Integer num = iter.next();
                result += num;
                count++;
                if (count < numbers.Count)
                    result += " - ";
            }
            return result;
        }

    }
}