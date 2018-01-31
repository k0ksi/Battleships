namespace Battleships.Engine.Components
{
    public class Panel
    {
        public Panel(int row, int col)
        {
            this.Coordinates = new Coordinates(row, col);
            this.BlockType = OccupationType.Empty;
        }

        public OccupationType BlockType { get; set; }

        public Coordinates Coordinates { get; set; }

        public string Status
        {
            get
            {
                string result = null;

                switch (this.BlockType)
                {
                    case OccupationType.Empty:
                        result = "o";
                        break;
                    case OccupationType.Battleship:
                        result = "B";
                        break;
                    case OccupationType.FirstDestroyer:
                        result = "F";
                        break;
                    case OccupationType.SecondDestoyer:
                        result = "S";
                        break;
                    case OccupationType.Hit:
                        result = "X";
                        break;
                    case OccupationType.Miss:
                        result = "M";
                        break;
                    default:
                        break;
                }

                return result;
            }
        }

        public bool IsOccupied => this.BlockType == OccupationType.Battleship ||
                                  this.BlockType == OccupationType.FirstDestroyer ||
                                  this.BlockType == OccupationType.SecondDestoyer;

        public bool IsRandomAvailable => (this.Coordinates.Row % 2 == 0 && this.Coordinates.Column % 2 == 0) ||
                                         (this.Coordinates.Row % 2 == 1 && this.Coordinates.Column % 2 == 1);
    }
}
