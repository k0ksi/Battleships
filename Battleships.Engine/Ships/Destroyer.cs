using Battleships.Engine.Components;

namespace Battleships.Engine.Ships
{
    public abstract class Destroyer : Ship
    {
        private const int DestroyerLength = 4;
        private const string DestroyerName = "Destroyer";

        public Destroyer()
        {
            this.Name = DestroyerName;
            this.Width = DestroyerLength;
        }
    }
}
