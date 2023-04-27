using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DBFrandomizer.Randomizer
{
    public class RandomNumber
    {
        private readonly RNGCryptoServiceProvider _rngCrypto;

        public RandomNumber()
        {
            _rngCrypto = new RNGCryptoServiceProvider();
        }

        public int Next(int minValue, int maxValue)
        {
            if (minValue >= maxValue)
                throw new ArgumentOutOfRangeException(nameof(minValue), "minValue must be less than maxValue");

            byte[] randomNumber = new byte[4];
            int value;

            do
            {
                _rngCrypto.GetBytes(randomNumber);
                value = System.BitConverter.ToInt32(randomNumber, 0);
            } while (value < minValue || value >= maxValue);

            return value;
        }

        public int Next(int maxValue)
        {
            return Next(0, maxValue);
        }

        public int Next()
        {
            return Next(int.MinValue, int.MaxValue);
        }

        public List<int> GetNumbers(int minValue, int maxValue, int count)
        {
            if (count > (maxValue - minValue))
                throw new ArgumentException("count cannot be greater than the range between minValue and maxValue");

            List<int> randomList = new List<int>();

            for (int i = minValue; i < maxValue; i++)
            {
                randomList.Add(i);
            }

            for (int i = 0; i < count; i++)
            {
                int randomIndex = Next(i, maxValue);
                int temp = randomList[randomIndex];
                randomList[randomIndex] = randomList[i];
                randomList[i] = temp;
            }

            return randomList.GetRange(0, count);
        }

        public List<int> GetNumbers(int minValue, int maxValue, int count, List<int> excludeList)
        {
            if (count > (maxValue - minValue) - excludeList.Count)
                throw new ArgumentException("count cannot be greater than the range between minValue and maxValue, minus the number of excluded values");

            List<int> randomList = new List<int>();

            for (int i = minValue; i < maxValue; i++)
            {
                if (!excludeList.Contains(i))
                    randomList.Add(i);
            }

            for (int i = 0; i < count; i++)
            {
                int randomIndex = Next(i, randomList.Count);
                int temp = randomList[randomIndex];
                randomList[randomIndex] = randomList[i];
                randomList[i] = temp;
            }

            return randomList.GetRange(0, count);
        }

        public int Probability(int[] itemsProbability)
        {
            List<double> pool = itemsProbability.Select(x => x / 100.0).ToList();

            double NextDouble()
            {
                byte[] randomNumber = new byte[4];
                _rngCrypto.GetBytes(randomNumber);
                return System.BitConverter.ToUInt32(randomNumber, 0) / (double)uint.MaxValue;
            }

            double Next()
            {
                double u = pool.Sum(p => p);
                double r = NextDouble() * u;

                double sum = 0;
                foreach (double n in pool)
                {
                    if (r <= (sum = sum + n))
                    {
                        return n;
                    }
                }

                return 0.0;
            }

            return pool.IndexOf(Next());
        }
    }
}