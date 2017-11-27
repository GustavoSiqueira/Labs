using System.Text;

namespace Conway
{
    internal sealed class Board
    {
        private int[] _board;
        private int[] _cache;
        private int _size;

        internal Board(int size)
        {
            _board = new int[size * size];
            _size = size;
        }

        internal void SetCell(int index, bool isAlive)
        {
            _board[index] = isAlive ? 1 : 0;
        }

        internal void Update()
        {
            _cache = new int[_board.Length];

            for (int i = 0; i < _board.Length; i++)
            {
                _cache[i] = UpdateCellState(i);
            }

            _board = _cache;
        }

        internal int Size
        {
            get
            {
                if (_board == null)
                {
                    return 0;
                }

                return _board.Length;
            }
        }

        internal string Render()
        {
            StringBuilder output = new StringBuilder();

            for (int i = 1; i <= _board.Length; i++)
            {
                output.Append(_board[i - 1] == 1 ? "X" : "-");

                if (i % _size == 0)
                {
                    output.Append("\r\n");
                }
            }

            return output.ToString();
        }

        private int UpdateCellState(int index)
        {
            int sum = 0;

            // row above
            if (index > _size) sum += _board[index - _size - 1];
            if (index > _size - 1) sum += _board[index - _size];
            if (index > _size - 2) sum += _board[index - _size + 1];

            // same row
            if (index > 0) sum += _board[index - 1];
            if (index < _board.Length - 1) sum += _board[index + 1];

            // row below
            if (index + _size - 1 < _board.Length) sum += _board[index + _size - 1];
            if (index + _size < _board.Length) sum += _board[index + _size];
            if (index + _size + 1 < _board.Length) sum += _board[index + _size + 1];

            if (_board[index] == 1)
            {
                // less than 2 or  more than 3 neighbors --> cell dies of loneliness or starvation
                if (sum < 2 || sum > 3)
                {
                    return 0;
                }
            }
            else
            {
                // dead cell with three neighbors becomes alive
                if (sum == 3)
                {
                    return 1;
                }
            }

            return _board[index];
        }

        internal static Board GetGlider(int size)
        {
            var board = new Board(size);
            board.SetCell(0, true);
            board.SetCell(size + 2, true);
            board.SetCell(2 * size, true);
            board.SetCell(2 * size + 1, true);
            board.SetCell(2 * size + 2, true);

            return board;
        }
    }
}
