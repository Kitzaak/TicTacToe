using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TicTacToe
{
    public class Board
    {
        public string Show()
        {
            return "   1  2  3\n1 [ ][ ][ ]\n2 [ ][ ][ ]\n3 [ ][ ][ ]\n";
        }
        public string Show(List<char> pieces)
        {
            return $"   1  2  3\n" +
                   $"1 [{pieces[0]}][{pieces[1]}][{pieces[2]}]\n" +
                   $"2 [{pieces[3]}][{pieces[4]}][{pieces[5]}]\n" +
                   $"3 [{pieces[6]}][{pieces[7]}][{pieces[8]}]\n";
        }
    }
}