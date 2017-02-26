using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Systems.Healing
{
    struct HealAmount
    {
        public static HealAmount Zero { get; } = new HealAmount(0);

        long _amount;
        public HealAmount(long amount)
        {
            _amount = amount;
        }

        public static bool operator <=(HealAmount left, HealAmount right)
        {
            return left._amount <= right._amount;
        }
        public static bool operator >=(HealAmount left, HealAmount right)
        {
            return left._amount >= right._amount;

        }

        public static HealAmount operator *(HealAmount left, long right)
        {
            return new HealAmount();
        }
        public static HealAmount operator *(long left, HealAmount right)
        {
            return new HealAmount();
        }
    }
}
