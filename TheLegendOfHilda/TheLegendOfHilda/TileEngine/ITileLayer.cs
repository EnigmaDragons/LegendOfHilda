using MonoDragons.Core.Engine;

namespace TheLegendOfHilda.TileEngine
{
    public interface ITileLayer : IVisualAutomaton
    {
        int Layer { get; }
        TileLocation Location { get; }
    }
}
