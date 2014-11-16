using System.Collections.Generic;
using System.Linq;

namespace GameOfLife.Core
{
    public class WrappingSquareWorld
    {
        private readonly int _width;
        private readonly int _height;
        private readonly Cell[] _cellsArray;
        private readonly Dictionary<Cell, Position> _cellPositions; 

        public WrappingSquareWorld(int width, int height)
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
            
            var results = new List<Cell>();
            var offsets = new[] {-1, 0, 1};
            foreach (var rowOffset in offsets)
            {
                var neighbourRow = (position.Row + rowOffset + _height) % _height;
                foreach (var columnOffset in offsets)
                {
                    var neighbourColumn = (position.Column + columnOffset + _width)%_width;
                    var neighbourIndex = GetIndex(_width, neighbourRow, neighbourColumn);
                    var neighbour = _cellsArray[neighbourIndex];
                    results.Add(neighbour);
                }
            }
            results.Remove(cell);
            return results;
        }

        class Position
        {
            public Position(int row, int column)
            {
                Column = column;
                Row = row;
            }

            public int Row { get; private set; }
            public int Column { get; private set; }
        }

        public GameState CreateState(State[,] states)
        {
            var data = new Dictionary<Cell, State>();
            foreach (var cell in _cellsArray)
            {
                var position = _cellPositions[cell];
                var state = states[position.Row, position.Column];
                data[cell] = state;
            }
            return new GameState(data);
        }

        public Cell GetCell(int row, int column)
        {
            return _cellsArray[GetIndex(_width, row, column)];
        }
    }
}