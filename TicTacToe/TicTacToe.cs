using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Engine
    {
        private char _nextMark;
        private List<char> _pieces;

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
        public List<char> Pieces()
        {
            return _pieces;
        }

        public void Move(int row, int col)
        {
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
            if (IsFullBoard())
                return true;
            if (IsRowComplete())
                return true;
            if (IsColComplete())
                return true;
            return false;
        }

        private bool IsFullBoard()
        {
            var isFull = true;

            foreach (var pos in _pieces)
            {
                if (pos == ' ')
                    isFull = false;
            }

            return isFull;
        }

        private bool IsRowComplete()
        {
            var complete = false;
            
            if (_pieces[0] != ' ' && _pieces[0] == _pieces[1] && _pieces[0] == _pieces[2])
                complete = true;
            if (_pieces[3] != ' ' && _pieces[3] == _pieces[4] && _pieces[3] == _pieces[5])
                complete = true;
            if (_pieces[6] != ' ' && _pieces[6] == _pieces[7] && _pieces[6] == _pieces[8])
                complete = true;
            
            return complete;
        }

        private bool IsColComplete()
        {
            var complete = false;
            
            if (_pieces[0] != ' ' && _pieces[0] == _pieces[3] && _pieces[0] == _pieces[6])
                complete = true;
            if (_pieces[1] != ' ' && _pieces[1] == _pieces[4] && _pieces[1] == _pieces[7])
                complete = true;
            if (_pieces[2] != ' ' && _pieces[2] == _pieces[5] && _pieces[2] == _pieces[8])
                complete = true;
            
            return complete;
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