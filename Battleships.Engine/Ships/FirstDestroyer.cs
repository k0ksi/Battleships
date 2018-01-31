using Battleships.Engine.Components;

namespace Battleships.Engine.Ships
{
    public class FirstDestroyer : Destroyer
    {
        public FirstDestroyer()
            : base()
        {
            this.ShipType = OccupationType.FirstDestroyer;
        }
    }
}
