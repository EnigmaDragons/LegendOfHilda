using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using MonoDragons.Core.Collision;

namespace MonoDragons.Core.Physics
{
    public class ReallyStupidPositionTracker
    {
        public static ReallyStupidPositionTracker Instance { get; private set; }

        private HashSet<AxisAlignedBoundingBox> boxes = new HashSet<AxisAlignedBoundingBox>();

        public void IBlock(AxisAlignedBoundingBox box)
        {
            boxes.Add(box);
        }

        public void Reset()
        {
            ReallyStupidPositionTracker.Instance = new ReallyStupidPositionTracker();
        }

        public bool CanIGoHere(AxisAlignedBoundingBox box)
        {
            return boxes.Any(x => x.ToRect().Intersects(box.ToRect()));
        }
    }
}
