using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_LOGIC
{
    public static class Helper
    {
        public static void Insert<T>(this T[] current, int position, T[] other)
        {
            int indexOther = 0;
            int lengthOther = other.Length;

            for(int i = position; i< current.Length; i++)
            {
                current[i] = other[indexOther];
                indexOther++;

                if (indexOther == lengthOther) return;
            }

        }
    }
}
