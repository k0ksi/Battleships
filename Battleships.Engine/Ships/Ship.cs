using Battleships.Engine.Components;

namespace Battleships.Engine.Ships
{
    public abstract class Ship
    {
        public string Name { get; set; }

        public int Width { get; set; }

        public int Hits { get; set; }

        public OccupationType ShipType { get; set; }

        public bool IsSunk => this.Hits >= this.Width;
    }
}
