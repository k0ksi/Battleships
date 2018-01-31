namespace Battleships.Engine.Components
{
    public class Coordinates
    {
        public Coordinates(int row, int col)
        {
            this.Row = row;
            this.Column = col;
        }

        public int Row { get; set; }

        public int Column { get; set; }        
    }
}
