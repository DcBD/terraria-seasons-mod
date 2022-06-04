using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Seasons.Common.Classes.Utils
{
    public static class NumberUtils
    {
         /// <summary>
         /// Locks value to max and min.
         /// </summary>
         /// <param name="value">value to lock</param>
         /// <param name="min">min value</param>
         /// <param name="max">max value</param>
         /// <returns>min if value is smaller than min, max if value is greater that max or current value</returns>
        public static float ToMinMax(this float value, float min, float max)
        {
            if(value < min)
            {
                return min;
            }else if(value > max)
            {
                return max;
            }

            return value;
        }
    }
}
