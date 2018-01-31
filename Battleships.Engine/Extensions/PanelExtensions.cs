using Battleships.Engine.Components;
using System.Collections.Generic;
using System.Linq;

namespace Battleships.Engine.Extensions
{
    public static class PanelExtensions
    {
        public static IList<Panel> Range(this IList<Panel> panels, int startRow, int startColumn, int endRow, int endColumn)
        {
            return panels.Where(x => x.Coordinates.Row >= startRow &&
                                     x.Coordinates.Column >= startColumn &&
                                     x.Coordinates.Row <= endRow &&
                                     x.Coordinates.Column <= endColumn)
                         .ToList();
        }

        public static Panel At(this IList<Panel> panels, int row, int column)
        {
            return panels.Where(x => x.Coordinates.Row == row && x.Coordinates.Column == column).First();
        }
    }
}
