using TicTacToe;

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

    [Fact]
    public void game_over_when_all_fields_filled()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            'X', 'X', 'O',
            'O', 'O', 'X',
            'X', 'O', 'X'
        };
        engine.Move(1, 1);
        engine.Move(2, 2);        
        engine.Move(1, 2);
        engine.Move(1, 3);
        engine.Move(3, 1);
        engine.Move(2, 1);
        engine.Move(2, 3);
        engine.Move(3, 2);
        engine.Move(3, 3);

        Assert.Equal(pieces, engine.Pieces());
        Assert.True(engine.IsOver());
    }

    [Fact]
    public void game_over_when_same_in_row()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            ' ', ' ', ' ',
            'O', 'O', ' ',
            'X', 'X', 'X'
        };
        engine.Move(3, 1);
        engine.Move(2, 2);        
        engine.Move(3, 2);
        engine.Move(2, 1);
        engine.Move(3, 3);

        Assert.Equal(pieces, engine.Pieces());
        Assert.True(engine.IsOver());
    }

    [Fact]
    public void game_over_when_same_in_col()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            ' ', ' ', 'X',
            'O', 'O', 'X',
            ' ', ' ', 'X'
        };
        engine.Move(2, 3);
        engine.Move(2, 2);        
        engine.Move(1, 3);
        engine.Move(2, 1);
        engine.Move(3, 3);

        Assert.Equal(pieces, engine.Pieces());
        Assert.True(engine.IsOver());
    }

    [Fact]
    public void game_over_when_same_in_diagonal()
    {
        var engine = new Engine();

        var pieces = new List<char>
        {
            'X', ' ', ' ',
            'O', 'X', 'O',
            ' ', ' ', 'X'
        };
        engine.Move(2, 2);
        engine.Move(2, 1);        
        engine.Move(1, 1);
        engine.Move(2, 3);
        engine.Move(3, 3);

        Assert.Equal(pieces, engine.Pieces());
        Assert.True(engine.IsOver());
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
}