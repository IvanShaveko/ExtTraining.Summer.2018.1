using System;
using System.Collections.Generic;

namespace MazeLibrary
{   
    public class MazeSolver
    {
        private int[,] _mazeModel;

        #region Constructor
        public MazeSolver(int[,] mazeModel, int startX, int startY)
        {
            if (mazeModel == null)
            {
                throw new ArgumentNullException($"{nameof(mazeModel)} can not be null");
            }

            if (startX < 0 || startY < 0)
            {
                throw new ArgumentException($"{nameof(startX)} or {nameof(startY)} one of them is less than 0");
            }

            _mazeModel = mazeModel;
            StartX = startX;
            StartY = startY;
            Step = 1;
        }
        #endregion

        #region Properties
        public int StartX { get; private set; }
        public int StartY { get; private set; }
        public int Step { get; private set; }

        #endregion

        public int[,] MazeWithPass()
        {
            _mazeModel[StartX, StartY] = Step++;
            PassMaze();
            return _mazeModel;
        }

        public void PassMaze()
        {
            int rows = _mazeModel.GetUpperBound(0) + 1;
            int columns = _mazeModel.Length / rows;

            if (StartX != 0)
            {
                if (_mazeModel[StartX - 1, StartY] == 0)
                {
                    _mazeModel[StartX - 1, StartY] = Step++;
                    StartX--;
                    PassMaze();
                }
            }

            if (StartX != rows - 1)
            {
                if (_mazeModel[StartX + 1, StartY] == 0)
                {
                    _mazeModel[StartX + 1, StartY] = Step++;
                    StartX++;
                    PassMaze();
                }
            }

            if (StartY != 0)
            {
                if (_mazeModel[StartX, StartY - 1] == 0)
                {
                    _mazeModel[StartX, StartY - 1] = Step++;
                    StartY--;
                    PassMaze();
                }
            }

            if (StartY != columns - 1)
            {
                if (_mazeModel[StartX, StartY + 1] == 0)
                {
                    _mazeModel[StartX, StartY + 1] = Step++;
                    StartY++;
                    PassMaze();
                }
            }
        }
    }
}
