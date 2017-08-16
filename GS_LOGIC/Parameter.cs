using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS_LOGIC
{
    public class Parameter
    {
        private Type type;

        private int _IntVal;
        public int IntVal { get { return _IntVal; }  set { _IntVal = value; type = typeof(int); } }

        private Int16 _Int16Val;
        public Int16 Int16Val { get { return _Int16Val; } set { _Int16Val = value; type = typeof(Int16); } }
        
        private Int64 _Int64Val;
        public Int64 Int64Val { get { return _Int64Val; } set { _Int64Val = value; type = typeof(Int64); } }
        
        private byte _ByteVal;
        public byte ByteVal { get { return _ByteVal; } set { _ByteVal = value; type = typeof(byte); } }

        private UInt16 _UInt16Val;
        public UInt16 UInt16Val { get { return _UInt16Val; } set { _UInt16Val = value; type = typeof(UInt16); } }

        private UInt32 _UInt32Val;
        public UInt32 UInt32Val { get { return _UInt32Val; } set { _UInt32Val = value; type = typeof(UInt32); } }

        private UInt64 _UInt64Val;
        public UInt64 UInt64Val { get { return _UInt64Val; } set { _UInt64Val = value; type = typeof(UInt64); } }

        private float _floatVal;
        public float FloatVal { get { return _floatVal; } set { _floatVal = value; type = typeof(float); } }


        public byte[] getByte()
        {
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Byte:
                    return BitConverter.GetBytes(_ByteVal);
                case TypeCode.Int16:
                    return BitConverter.GetBytes(_Int16Val);
                case TypeCode.UInt16:
                    return BitConverter.GetBytes(_UInt16Val);
                case TypeCode.Int32:
                    return BitConverter.GetBytes(_IntVal);
                case TypeCode.UInt32:
                    return BitConverter.GetBytes(_UInt32Val);
                case TypeCode.Int64:
                    return BitConverter.GetBytes(_Int64Val);
                case TypeCode.UInt64:
                    return BitConverter.GetBytes(_UInt64Val);
                case TypeCode.Single:
                    return BitConverter.GetBytes(_floatVal);
                default: return null;
            }
        }

    }
}
