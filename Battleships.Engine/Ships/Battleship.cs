using Battleships.Engine.Components;

namespace Battleships.Engine.Ships
{
    public class Battleship : Ship
    {
        private const int BattleshipLength = 5;
        private const string BattleshipName = "Battleship";

        public Battleship()
        {
            this.Name = BattleshipName;
            this.Width = BattleshipLength;
            this.ShipType = OccupationType.Battleship;
        }
    }
}
