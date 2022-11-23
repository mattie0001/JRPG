using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemMechanics
{
    public static class RandomIntGen
    {
        private static Random random = new Random();

        public static int MedianNumber(int maxInt, int minInt)
        {
            return random.Next(minInt, maxInt + 1);
        }
    }
}
