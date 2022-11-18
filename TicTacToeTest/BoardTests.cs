using TicTacToe;
using Xunit;

namespace TicTacToeTest
{
    public class BoardTests
    {
        [Fact]
        public void can_show_empty_board()
        {
            var board = new Board();
            
            Assert.Equal("   1  2  3\n1 [ ][ ][ ]\n2 [ ][ ][ ]\n3 [ ][ ][ ]\n", board.Show());
        }
        
        [Fact]
        public void can_show_pieces_on_board()
        {
            var board = new Board();

            var pieces = new List<char>
            {
                'X', ' ', ' ',
                ' ', 'X', ' ',
                ' ', ' ', 'X'
            };
            
            Assert.Equal("   1  2  3\n1 [X][ ][ ]\n2 [ ][X][ ]\n3 [ ][ ][X]\n", board.Show(pieces));
        }
        
    }
}


