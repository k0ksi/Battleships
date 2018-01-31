using System.Collections.Generic;

namespace Battleships.Engine.Components
{
    public class GameBoard
    {
        private const int BoardSize = 10;

        public GameBoard()
        {
            this.Panels = new List<Panel>();
            this.InitializePanels();
        }        

        public List<Panel> Panels { get; set; }

        private void InitializePanels()
        {
            for (int i = 1; i <= BoardSize; i++)
            {
                for (int j = 1; j <= BoardSize; j++)
                {
                    Panels.Add(new Panel(i, j));
                }
            }
        }
    }
}
