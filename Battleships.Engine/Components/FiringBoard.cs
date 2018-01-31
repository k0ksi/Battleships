using System.Collections.Generic;
using System.Linq;
using Battleships.Engine.Extensions;

namespace Battleships.Engine.Components
{
    public class FiringBoard : GameBoard
    {
        public IList<Coordinates> GetOpenRandomPanels()
        {
            return this.Panels
                .Where(x => x.BlockType == OccupationType.Empty && x.IsRandomAvailable)
                .Select(x => x.Coordinates)
                .ToList();
        }

        public IList<Coordinates> GetHitNeighbours()
        {
            List<Panel> panels = new List<Panel>();
            var hits = this.Panels.Where(x => x.BlockType == OccupationType.Hit);
            foreach (var hit in hits)
            {
                panels.AddRange(this.GetNeighbours(hit.Coordinates).ToList());
            }

            return panels.Distinct().Where(x => x.BlockType == OccupationType.Empty).Select(x => x.Coordinates).ToList();
        }

        public IList<Panel> GetNeighbours(Coordinates coordinates)
        {
            int row = coordinates.Row;
            int column = coordinates.Column;
            List<Panel> panels = new List<Panel>();

            if (column > 1)
            {
                panels.Add(this.Panels.At(row, column - 1));
            }

            if (row > 1)
            {
                panels.Add(this.Panels.At(row - 1, column));
            }

            if (row < 10)
            {
                panels.Add(this.Panels.At(row + 1, column));
            }

            if (column < 10)
            {
                panels.Add(this.Panels.At(row, column + 1));
            }

            return panels;
        }
    }
}
