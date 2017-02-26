using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheLegendOfHilda.Systems.Healing
{
    class HealingSettings
    {
        public TimeSpan Interval { get; } = TimeSpan.FromSeconds(20);
        public HealAmount Amount { get; } = new HealAmount(1);
    }
}
