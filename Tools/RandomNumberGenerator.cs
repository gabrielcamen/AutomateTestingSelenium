using System;

namespace Tools
{
    public static class RandomNumberGenerator
    {
        public static int RandomNumberEven(int min = 0, int max = 18)
        {
            Random random = new Random();
            int ans = random.Next(min, max);
            if (ans % 2 == 0) return ans;
            else
            {
                if (ans + 1 <= max)
                    return ans + 1;
                else if (ans - 1 >= min)
                    return ans - 1;
                else return 0;
            }
        }
    }
   
}
