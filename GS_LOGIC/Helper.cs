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

        //public static Parameter generateRandomValue(Type type)
        //{
        //    //TODO: search a random alternative that can handle uints and int64 ranges
        //    Random rand = new Random();
        //    Parameter val = new Parameter();
            

        //    switch (type.ToString())
        //    {
        //        case "System.Byte":
        //            val.ByteVal = byte.Parse((rand.Next(byte.MinValue, byte.MaxValue)).ToString());
        //            break;
        //        case "System.UInt16":
        //            val.UInt16Val = UInt16.Parse((rand.Next(UInt16.MinValue, UInt16.MaxValue)).ToString());
        //            break;
        //        //case "System.UInt32":
        //        //    val.UInt32Val = UInt32.Parse((rand.Next(UInt32.MinValue, UInt32.MaxValue)).ToString());
        //        //    break;
        //        //case "System.UInt64":
        //        //    val.UInt32Val = UInt32.Parse((rand.Next(UInt32.MinValue, UInt32.MaxValue)).ToString());
        //        //    break;
        //        case "System.Int16":
        //            val.Int16Val = Int16.Parse((rand.Next(Int16.MinValue, Int16.MaxValue)).ToString());
        //            break;
        //        case "System.Int32":
        //            val.IntVal = int.Parse((rand.Next(int.MinValue, int.MaxValue)).ToString());
        //            break;
        //        case "System.Int64":
        //            val.ByteVal = byte.Parse((rand.Next(byte.MinValue, byte.MaxValue)).ToString());
        //            break;
        //        case "System.Single":
        //            val.ByteVal = byte.Parse((rand.Next(byte.MinValue, byte.MaxValue)).ToString());
        //            break;
        //      return val;
        //    }
        }
}
