using System;
using System.Collections.Generic;

namespace RandomList
{
    /// <summary>
    /// represents a list generator
    /// </summary>
    public class ListGenerator
    {
        private readonly IRandom _random;

        public ListGenerator(IRandom random)
        {
            _random = random;
        }

        /// <summary>
        /// Generates a randomly ordered list of numbers
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <param name="sorted">defines weather the output should be sorted or not</param>
        /// <returns></returns>
        public List<int> Generate(int min, int max, bool sorted)
        {
            if (min > max)
                throw new ArgumentOutOfRangeException($"min must be lower than max");

            var list = new List<int>();

            GetList(list,min,max, sorted);

            return list;
        }

        private void GetList(ICollection<int> list, int min, int max, bool sorted)
        {
            void NewFunction(int i)
            {
                list.Add(i);
            }

            if (min > max)
                return;

            var r = _random.Random(min, max);

            if (!sorted)
                NewFunction(r);

            GetList(list, min, r - 1, sorted);

            if (sorted)
                NewFunction(r);

            GetList(list, r + 1, max, sorted);
        }
    }
}
