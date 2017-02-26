using System.Collections.Generic;
using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public interface ITileLayer : IVisualAutomaton
    {
        int Layer { get; }
        TileLocation Location { get; }
        List<TileLocation> Locations { get; }
    }
}
