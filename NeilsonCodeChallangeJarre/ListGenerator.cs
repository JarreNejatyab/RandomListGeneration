﻿using System.Collections.Generic;

namespace NeilsonCodeChallangeJarre
{
    public class ListGenerator
    {
        private readonly IRandom _random;

        public ListGenerator(IRandom random)
        {
            _random = random;
        }

        public List<int> Generate(int min, int max)
        {
            var list = new List<int>();

            GetList(list,min,max);

            return list;
        }

        private void GetList(ICollection<int> list, int min, int max)
        {
            if (min > max)
                return;

            var r = _random.Random(min, max);

            list.Add(r);

            GetList(list, min, r - 1);
            GetList(list, r + 1, max);
        }
    }
}