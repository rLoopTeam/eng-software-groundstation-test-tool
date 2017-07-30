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

        public static float getRandomFloat(Random random, int min, int max)
        {
            float baseNumber = random.Next(min, (max-1));
            float pointNumber = Convert.ToSingle(random.NextDouble());

            return baseNumber + pointNumber;
        }

        public static T[] Slice<T>(this T[] current, int from, int count)
        {
            T[] newArray = new T[count];

            for (int i = 0; i < count; i++)
            {
                newArray[i] = current[from];
                from++;

                if (from == current.Length) return newArray;
            }
            return newArray;
        }
    }
}
