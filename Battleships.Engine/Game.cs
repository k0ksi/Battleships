using Battleships.Engine.Components;
using System;

namespace Battleships.Engine
{
    public class Game
    {
        //public Game()
        //{
        //    //this.FirstPlayer.PlaceShips();
        //    //this.SecondPlayer.PlaceShips();
        //    //this.PlayerPlaceShips();
        //    //this.ComPlayerPlaceChips();

        //    this.FirstPlayer.OutputBoards();
        //    this.SecondPlayer.OutputBoards();
        //}

        public void PlayerPlaceShips()
        {
            this.FirstPlayer.PlaceShips();
        }

        public void ComPlayerPlaceChips()
        {
            this.SecondPlayer.PlaceShips();
        }

        public Player FirstPlayer { get; set; }

        public Player SecondPlayer { get; set; }

        public int SelectedRow { get; set; }

        public int SelectedCol { get; set; }

        public ShotResult PlayerPlaceShot(int row, int col)
        {
            var coordinates = this.FirstPlayer.FireShotWithCoordinates(row, col, this.SecondPlayer.GameBoard);
            var result = this.SecondPlayer.ProcessShot(coordinates);

            return result;
        }

        public void PlayRound()
        {
            var coordinates = this.FirstPlayer.FireShot();
            var result = this.SecondPlayer.ProcessShot(coordinates);
            this.FirstPlayer.ProcessShotResult(coordinates, result);

            if (!this.SecondPlayer.HasLost)
            {
                coordinates = this.SecondPlayer.FireShot();
                result = this.FirstPlayer.ProcessShot(coordinates);
                this.SecondPlayer.ProcessShotResult(coordinates, result);
            }
        }

        public void PlayToEnd()
        {
            while (!this.FirstPlayer.HasLost && !this.SecondPlayer.HasLost)
            {
                this.PlayRound();

                this.FirstPlayer.OutputBoards();
                this.SecondPlayer.OutputBoards();
            }

            this.FirstPlayer.OutputBoards();
            this.SecondPlayer.OutputBoards();

            if (this.FirstPlayer.HasLost)
            {
                Console.WriteLine(this.SecondPlayer.Name + " has won the game!");
            }
            else if (this.SecondPlayer.HasLost)
            {
                Console.WriteLine(this.FirstPlayer.Name + " has won the game!");
            }
        }
    }
}
