using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoDragons.Ecstasy
{
    public struct ElapsedGameTime
    {
        public static ElapsedGameTime Zero { get; } = new ElapsedGameTime(TimeSpan.Zero);

        TimeSpan _elapsed;
        public ElapsedGameTime(TimeSpan elapsed) : this()
        {
            _elapsed = elapsed;
        }

        public static bool operator >=(ElapsedGameTime left, TimeSpan right)
        {
            var result = left._elapsed >= right;
            return result;
        }
        public static bool operator <=(ElapsedGameTime left, TimeSpan right)
        {
            var result = left._elapsed <= right;
            return result;
        }

        public static ElapsedGameTime operator +(ElapsedGameTime left, ElapsedGameTime right)
        {
            var result = new ElapsedGameTime(left._elapsed.Add(right._elapsed));
            return result;
        }

        public static long operator /(ElapsedGameTime left, TimeSpan right)
        {
            var result = left._elapsed.Ticks / right.Ticks;
            return result;
        }

        public static long operator /(FrameCount left, ElapsedGameTime right)
        {
            var result = left / right._elapsed.TotalSeconds;
            return result;
        }
    }
}
