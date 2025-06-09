using System;

namespace LotteryService
{
    public class MyRandomNumberGenerator : INumberGenerator
    {
        private  Random rand = new Random();

        public int generate(int limit)
        {
            return rand.Next(limit);
        }
    }
}
