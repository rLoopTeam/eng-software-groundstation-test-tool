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
            for (int i = 0; i < other.Length; i++)
            {
                current[position] = other[i];
                position++;

                if (position == current.Length) return;
            }
        }
    }
}
