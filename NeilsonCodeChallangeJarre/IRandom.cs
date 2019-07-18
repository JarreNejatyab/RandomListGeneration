using System;
using System.Collections.Generic;
using System.Text;

namespace NeilsonCodeChallangeJarre
{
    public interface IRandom
    {
        /// <summary>
        /// generate a random number between <see cref="min"/> and <see cref="max"/> exclusively
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        int Random(int min, int max);
    }
}
