using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class SquareWorld
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Cell[] _cellsArray;
        private Dictionary<Cell, Position> _cellPositions; 

        public SquareWorld(int width, int height)
        {
            _width = width;
            _height = height;
            _cellsArray = new Cell[width*height];
            _cellPositions = new Dictionary<Cell, Position>();
            foreach (var row in Enumerable.Range(0, height))
            {
                foreach (var column in Enumerable.Range(0, width))
                {
                    var cell = new Cell();
                    _cellsArray[GetIndex(width, row, column)] = cell;
                    _cellPositions[cell] = new Position(row, column);
                }
            }
        }

        private static int GetIndex(int width, int row, int column)
        {
            return row*width+column;
        }

        public IEnumerable<Cell> WorldCells
        {
            get { return _cellsArray; }
        }

        public IEnumerable<Cell> GetNeighbours(Cell cell)
        {
            var position = _cellPositions[cell];
            var arrayIndex = GetIndex(_width, position.Row, position.Column);
            
            var results = new List<Cell>();
            
            results.Add(_cellsArray[arrayIndex - 1]);
            results.Add(_cellsArray[arrayIndex + 1]);
            results.Add(_cellsArray[arrayIndex - _width]);
            results.Add(_cellsArray[arrayIndex + _width]);

            return results;
        } 
    }

    internal class Position
    {
        public Position(int row, int column)
        {
            Column = column;
            Row = row;
        }

        public int Row { get; private set; }
        public int Column { get; private set; }
    }
}
