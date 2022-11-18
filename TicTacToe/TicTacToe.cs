namespace TicTacToe
{
    public class Engine
    {
        char _nextMark;
        List<char> _pieces;
        string _whowon = "No one yet!";
        bool _gameOver = false;

        public char NextMark
        {
            get => _nextMark;
        }

        public Engine()
        {
            _nextMark = 'X';
            _pieces = new List<char>
            {
                ' ', ' ', ' ',
                ' ', ' ', ' ',
                ' ', ' ', ' '
            };
        }

        public Engine(List<char> pieces)
        {
            _pieces = pieces;
            int X = 0;
            int O = 0;
            foreach(char piece in _pieces)
            {
                if (piece == 'X')
                    X++;
                else if (piece == 'O')
                    O++;
            }

            if (X == O)
                _nextMark = 'X';
            else
                _nextMark = 'O';
        }

        public string WhoWon()
        {
            IsOver();

            return _whowon;
        }

        public List<char> Pieces()
        {
            return _pieces;
        }

        public void Move(int row, int col)
        {
            if (IsOver())
                throw new Exception("Game over. No more moves.");

            if (_pieces[MovePosition(row, col)] == ' ')
            {
                _pieces[MovePosition(row, col)] = _nextMark;

                _nextMark = _nextMark == 'X' ? 'O' : 'X';
            }
            else
                throw new Exception("Board field already taked.");
        }

        public bool IsOver()
        {
            IsFullBoard();
            IsRowComplete();
            IsColComplete();
            IsDiagonalComplete();

            return _gameOver;
        }

        private void IsFullBoard()
        {
            bool isCatsGame = true;
            foreach (var pos in _pieces)
            {
                if (pos == ' ')
                    isCatsGame = false;
            }

            if (isCatsGame)
            {
                _gameOver = true;
                _whowon = "Cat's game!";
            }
        }

        private void IsRowComplete()
        {
            if (_pieces[0] != ' ' && _pieces[0] == _pieces[1] && _pieces[0] == _pieces[2])
                SetEndAndWinner(_pieces[0]);
            if (_pieces[3] != ' ' && _pieces[3] == _pieces[4] && _pieces[3] == _pieces[5])
                SetEndAndWinner(_pieces[3]);
            if (_pieces[6] != ' ' && _pieces[6] == _pieces[7] && _pieces[6] == _pieces[8])
                SetEndAndWinner(_pieces[6]);
        }

        private void IsColComplete()
        {
            if (_pieces[0] != ' ' && _pieces[0] == _pieces[3] && _pieces[0] == _pieces[6])
                SetEndAndWinner(_pieces[0]);
            if (_pieces[1] != ' ' && _pieces[1] == _pieces[4] && _pieces[1] == _pieces[7])
                SetEndAndWinner(_pieces[1]);
            if (_pieces[2] != ' ' && _pieces[2] == _pieces[5] && _pieces[2] == _pieces[8])
                SetEndAndWinner(_pieces[2]);
        }

        private void IsDiagonalComplete()
        {
            if (_pieces[0] != ' ' && _pieces[0] == _pieces[4] && _pieces[0] == _pieces[8])
                SetEndAndWinner(_pieces[0]);
            if (_pieces[2] != ' ' && _pieces[2] == _pieces[4] && _pieces[2] == _pieces[6])
                SetEndAndWinner(_pieces[2]);
        }

        private void SetEndAndWinner(char winner)
        {
            _gameOver = true;
            _whowon = $"{winner}";
        }

        private int MovePosition(int row, int col)
        {
            int pos = 0;
            if (row == 1)
            {
                if (col == 1)
                    pos = 0;
                else if (col == 2)
                    pos = 1;
                else
                    pos = 2;
            }
            else if (row == 2)
            {
                if (col == 1)
                    pos = 3;
                else if (col == 2)
                    pos = 4;
                else
                    pos = 5;
            }
            else if (row == 3)
            {
                if (col == 1)
                    pos = 6;
                else if (col == 2)
                    pos = 7;
                else
                    pos = 8;
            }
            return pos;
        }
    }
}