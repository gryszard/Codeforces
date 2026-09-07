using Codeforces.Utilities;

namespace Codeforces._0710;

public class A_King_Moves(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        if (nextLine.Length != 2)
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        int column = nextLine[0] - 'a' + 1;
        int row = nextLine[1] - '1' + 1;

        IncrementIfCanMove(column - 1, row - 1);
        IncrementIfCanMove(column - 1, row);
        IncrementIfCanMove(column - 1, row + 1);
        IncrementIfCanMove(column, row - 1);
        IncrementIfCanMove(column, row + 1);
        IncrementIfCanMove(column + 1, row - 1);
        IncrementIfCanMove(column + 1, row);
        IncrementIfCanMove(column + 1, row + 1);

        _textWriter.WriteLine(moveCounter);
    }

    private void IncrementIfCanMove(int column, int row)
    {
        if (1 <= column && column <= 8 &&
            1 <= row && row <= 8)
        {
            moveCounter++;
        }
    }

    private int moveCounter = 0;
}
