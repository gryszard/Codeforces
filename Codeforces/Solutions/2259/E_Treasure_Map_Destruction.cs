using Codeforces.Utilities;

namespace Codeforces._2259;

public class E_Treasure_Map_Destruction(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var array = FetchTokens(n);

        treasureMap = new int[n];
        buffer = [(-1, -1), (-1, -1)];
        bufferSize = 0;

        for (int i = 0; i < n; i++)
        {
            if (array[i] == -1)
            {
                continue;
            }

            PutValue(i, array[i]);
            if (!Analyze())
            {
                _textWriter.WriteLine(-1);
                return;
            }
        }

        if (bufferSize == 0)
        {
            treasureMap[0] = 1;
        }

        if (bufferSize > 0 && buffer[0].Index + buffer[0].Distance < n)
        {
            treasureMap[buffer[0].Index + buffer[0].Distance] = 1;
        }

        if (bufferSize > 0 && buffer[0].Index + buffer[0].Distance >= n && descending)
        {
            _textWriter.WriteLine(-1);
            return;
        }

        _textWriter.WriteLine(string.Join(string.Empty, treasureMap));
    }

    private int[] treasureMap = [];
    private (int Index, int Distance)[] buffer = [];
    private int bufferSize = 0;
    private bool descending = false;

    private void PutValue(int index, int distance)
    {
        buffer[1] = buffer[0];
        buffer[0] = (index, distance);

        bufferSize = Math.Min(bufferSize + 1, 2);
    }

    private void PopValue()
    {
        bufferSize--;
    }

    private bool Analyze()
    {
        if (bufferSize == 1 && buffer[0].Index < buffer[0].Distance)
        {
            descending = true;
            return true;
        }

        if (bufferSize == 1)
        {
            treasureMap[buffer[0].Index - buffer[0].Distance] = 1;
            descending = false;
            return true;
        }

        // bufferSize == 2
        if (buffer[0].Index - buffer[1].Index < Math.Abs(buffer[0].Distance - buffer[1].Distance))
        {
            return false;
        }

        if (buffer[0].Index - buffer[1].Index >= Math.Abs(buffer[0].Distance + buffer[1].Distance))
        {
            treasureMap[buffer[0].Index - buffer[0].Distance] = 1;
            treasureMap[buffer[1].Index + buffer[1].Distance] = 1;
            descending = false;
            PopValue();
            return true;
        }

        if (descending && buffer[0].Distance > buffer[1].Distance - (buffer[0].Index - buffer[1].Index))
        {
            return false;
        }

        if (!descending && buffer[0].Distance < buffer[1].Distance + (buffer[0].Index - buffer[1].Index))
        {
            descending = true;
            PopValue();
            return true;
        }

        PopValue();
        return true;
    }
}
