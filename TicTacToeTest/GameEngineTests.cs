using TicTacToe;
using Xunit;

namespace TicTacToeTest;

public class UnitTest1
{
    [Fact]
    public void piece_arry_starts_empty()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            ' ', ' ', ' ',
            ' ', ' ', ' ',
            ' ', ' ', ' '
        };
        
        Assert.Equal(pieces, engine.Pieces());
    }
    
    [Fact]
    public void can_make_move_X_is_first()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            'X', ' ', ' ',
            ' ', ' ', ' ',
            ' ', ' ', ' '
        };
        engine.Move(1, 1);
        
        Assert.Equal(pieces, engine.Pieces());
    }
    
    [Fact]
    public void can_make_second_move()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            'X', ' ', ' ',
            ' ', 'O', ' ',
            ' ', ' ', ' '
        };
        engine.Move(1, 1);
        engine.Move(2, 2);
        
        Assert.Equal(pieces, engine.Pieces());
    }
    
    [Fact]
    public void do_not_allow_over_write()
    {
        var engine = new Engine();

        engine.Move(1, 1);

        Assert.Throws<Exception>(() => engine.Move(1, 1));
    }

    [Fact]
    public void game_is_not_compete_at_start()
    {
        var engine = new Engine();

        Assert.False(engine.IsOver());
    }
    
    [Theory]
    [InlineData('X', ' ', ' ', 'X', 'O', 'O', ' ', ' ', 'X', 'O')]
    [InlineData('X', ' ', ' ', 'X', 'O', 'O', 'O', ' ', 'X', 'X')]
    public void can_load_pieces_into_engine(char field1, char field2, char field3, char field4, char field5, char field6, char field7, char field8, char field9, char NextMark)
    {
        var pieces = new List<char>
        {
            field1, field2, field3,
            field4, field5, field6,
            field7, field8, field9
        };

        var engine = new Engine(pieces);

        Assert.Equal(pieces, engine.Pieces());
        Assert.Equal(NextMark, engine.NextMark);
    }

    [Theory]
    [InlineData('X', 'X', 'O', 'O', 'X', 'X', 'X', 'O', 'O')]
    [InlineData('X', 'X', 'X', ' ', 'O', ' ', ' ', 'O', ' ')]
    [InlineData('X', 'X', ' ', 'O', 'O', 'O', ' ', 'X', ' ')]
    [InlineData(' ', ' ', 'O', ' ', 'O', ' ', 'X', 'X', 'X')]
    [InlineData('X', ' ', ' ', 'X', 'O', 'O', 'X', ' ', ' ')]
    [InlineData('X', 'O', 'O', ' ', 'O', ' ', 'X', 'O', ' ')]
    [InlineData('O', 'O', 'X', ' ', ' ', 'X', ' ', ' ', 'X')]
    [InlineData('X', 'O', ' ', ' ', 'X', ' ', ' ', 'O', 'X')]
    [InlineData('X', 'X', 'O', ' ', 'O', ' ', 'O', 'X', ' ')]
    public void game_over(char field1, char field2, char field3, char field4, char field5, char field6, char field7, char field8, char field9)
    {
        var pieces = new List<char>
        {
            field1, field2, field3,
            field4, field5, field6,
            field7, field8, field9
        };

        var engine = new Engine(pieces);

        Assert.True(engine.IsOver());
    }

    [Fact]
    public void expect_exception_if_move_after_is_over()
    {
        var pieces = new List<char>
        {
            'X', 'O', 'O',
            ' ', 'X', ' ',
            ' ', ' ', 'X'
        };

        var engine = new Engine(pieces);

        Assert.True(engine.IsOver());
        Assert.Throws<Exception>(() => engine.Move(3, 1));
    }

    [Theory]
    [InlineData(' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', "No one yet!")]
    [InlineData('X', 'X', 'O', 'O', 'X', 'X', 'X', 'O', 'O', "Cat's game!")]
    [InlineData('X', 'X', 'X', ' ', 'O', ' ', ' ', 'O', ' ', "X")]
    [InlineData('X', 'X', ' ', 'O', 'O', 'O', ' ', 'X', ' ', "O")]
    [InlineData(' ', ' ', 'O', ' ', 'O', ' ', 'X', 'X', 'X', "X")]
    [InlineData('X', ' ', ' ', 'X', 'O', 'O', 'X', ' ', ' ', "X")]
    [InlineData('X', 'O', 'O', ' ', 'O', ' ', 'X', 'O', ' ', "O")]
    [InlineData('O', 'O', 'X', ' ', ' ', 'X', ' ', ' ', 'X', "X")]
    [InlineData('X', 'O', ' ', ' ', 'X', ' ', ' ', 'O', 'X', "X")]
    [InlineData('X', 'X', 'O', ' ', 'O', ' ', 'O', 'X', ' ', "O")]
    public void who_won(char field1, char field2, char field3, char field4, char field5, char field6, char field7, char field8, char field9, string who_won)
    {
        var pieces = new List<char>
        {
            field1, field2, field3,
            field4, field5, field6,
            field7, field8, field9
        };

        var engine = new Engine(pieces);

        Assert.Equal(who_won, engine.WhoWon());
    }
}