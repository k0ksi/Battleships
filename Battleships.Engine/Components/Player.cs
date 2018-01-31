using Battleships.Engine.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using Battleships.Engine.Extensions;

namespace Battleships.Engine.Components
{
    public class Player
    {
        public Player(string name)
        {
            this.Name = name;
            this.Ships = this.InitPlayerShips();
            this.GameBoard = new GameBoard();
            this.FiringBoard = new FiringBoard();
        }

        public string Name { get; set; }

        public GameBoard GameBoard { get; set; }

        public FiringBoard FiringBoard { get; set; }

        public IList<Ship> Ships { get; set; }

        public bool HasLost => this.Ships.All(x => x.IsSunk);
        
        public void PlaceShips()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());

            foreach (var ship in this.Ships)
            {
                bool isOpen = true;

                while (isOpen)
                {
                    var startColumn = random.Next(1, 11);
                    var startRow = random.Next(1, 11);
                    int endRow = startRow;
                    int endColumn = startColumn;
                    var orientation = random.Next(1, 101) % 2;

                    List<int> panelNumbers = new List<int>();
                    if(orientation == 0)
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endRow++;
                        }
                    }
                    else
                    {
                        for (int i = 1; i < ship.Width; i++)
                        {
                            endColumn++;
                        }
                    }

                    if(endRow > 10 || endColumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    var affectedPanels = this.GameBoard.Panels.Range(startRow, startColumn, endRow, endColumn);
                    if(affectedPanels.Any(x => x.IsOccupied))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var panel in affectedPanels)
                    {
                        panel.BlockType = ship.ShipType;
                    }

                    isOpen = false;
                }
            }
        }

        public Coordinates FireShot()
        {
            var hitNeighbors = this.FiringBoard.GetHitNeighbours();
            Coordinates coordinates;
            if(hitNeighbors.Any())
            {
                coordinates = this.SearchingShot();
            }
            else
            {
                coordinates = this.RandomShot();
            }

            Console.WriteLine(Name + " says: \"Firing shot at " + coordinates.Row.ToString() + ", " + coordinates.Column.ToString() + "\"");

            return coordinates;
        }

        private Coordinates RandomShot()
        {
            var availablePanels = this.FiringBoard.GetOpenRandomPanels();

            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var panelId = rand.Next(availablePanels.Count);

            return availablePanels[panelId];
        }

        private Coordinates SearchingShot()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            var hitNeighbors = this.FiringBoard.GetHitNeighbours();
            var neighborId = rand.Next(hitNeighbors.Count);

            return hitNeighbors[neighborId];
        }

        public ShotResult ProcessShot(Coordinates coordinates)
        {
            var panel = this.GameBoard.Panels.At(coordinates.Row, coordinates.Column);

            if(!panel.IsOccupied)
            {
                Console.WriteLine(Name + " says: \"Miss!\"");

                return ShotResult.Miss;
            }

            var ship = this.GetCorrectShip(panel);

            ship.Hits++;

            Console.WriteLine(Name + " says: \"Hit!\"");

            if (ship.IsSunk)
            {
                Console.WriteLine(Name + " says: \"You sunk my " + ship.Name + "!\"");
            }

            return ShotResult.Hit;
        }

        public void ProcessShotResult(Coordinates coordinates, ShotResult shotResult)
        {
            var panel = this.FiringBoard.Panels.At(coordinates.Row, coordinates.Column);

            switch (shotResult)
            {
                case ShotResult.Hit:
                    panel.BlockType = OccupationType.Hit;
                    break;
                default:
                    panel.BlockType = OccupationType.Miss;
                    break;
            }
        }

        public void OutputBoards()
        {
            Console.WriteLine(Name);
            Console.WriteLine("Own Board:                          Firing Board:");
            for (int row = 1; row <= 10; row++)
            {
                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GameBoard.Panels.At(row, ownColumn).Status + " ");
                }
                Console.Write("                ");
                for (int firingColumn = 1; firingColumn <= 10; firingColumn++)
                {
                    Console.Write(FiringBoard.Panels.At(row, firingColumn).Status + " ");
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        private Ship GetCorrectShip(Panel panel)
        {
            return this.Ships.First(x => x.ShipType == panel.BlockType);
        }

        private IList<Ship> InitPlayerShips()
        {
            List<Ship> result = new List<Ship>
            {                
                new FirstDestroyer(),
                new SecondDestroyer(),
                new Battleship()
            };

            return result;
        }
    }
}
