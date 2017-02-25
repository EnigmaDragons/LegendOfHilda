using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public struct FrameCount
    {
        public static FrameCount Zero { get; } = new FrameCount(0);
        long _value;

        public FrameCount(long value)
        {
            _value = value;
        }

        public void Tick()
        {
            _value++;
        }
        public void Reset()
        {
            _value = 0;
        }


        public static long operator /(FrameCount left, double right)
        {
            var result = (long)(left._value / right);
            return result;
        }
    }

}
