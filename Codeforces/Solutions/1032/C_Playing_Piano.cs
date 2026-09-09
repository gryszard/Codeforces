using Codeforces.Utilities;

namespace Codeforces._1032;

public class C_Playing_Piano(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var keyNumbers = FetchTokens(n);
        var fingering = new int[keyNumbers.Count + 1];

        Direction direction = Direction.Ascending;
        fingering[0] = 2;
        fingering[1] = 1;

        for (int i = 1; i < keyNumbers.Count; i++)
        {
            if (keyNumbers[i - 1] == keyNumbers[i])
            {
                direction = Direction.Constant;
                fingering[i + 1] = fingering[i] == 2 ? 3 : 2;

                continue;
            }

            if (direction == Direction.Ascending)
            {
                if (keyNumbers[i - 1] < keyNumbers[i])
                {
                    fingering[i + 1] = fingering[i] + 1;

                    if (fingering[i + 1] > 5)
                    {
                        _textWriter.WriteLine(-1);
                        return;
                    }

                    continue;
                }

                direction = Direction.Descending;
                fingering[i] = 5;
                fingering[i + 1] = 4;

                continue;
            }

            if (direction == Direction.Descending)
            {
                if (keyNumbers[i - 1] > keyNumbers[i])
                {
                    fingering[i + 1] = fingering[i] - 1;

                    if (fingering[i + 1] < 1)
                    {
                        _textWriter.WriteLine(-1);
                        return;
                    }

                    continue;
                }

                direction = Direction.Ascending;
                fingering[i] = 1;
                fingering[i + 1] = 2;

                continue;
            }

            if (keyNumbers[i - 1] < keyNumbers[i])
            {
                direction = Direction.Ascending;
                fingering[i] = 1;
                fingering[i + 1] = 2;

                if (fingering[i - 1] == 1)
                {
                    fingering[i] = 2;
                    fingering[i + 1] = 3;
                }

                continue;
            }

            direction = Direction.Descending;
            fingering[i] = 5;
            fingering[i + 1] = 4;

            if (fingering[i - 1] == 5)
            {
                fingering[i] = 4;
                fingering[i + 1] = 3;
            }
        }

        _textWriter.WriteLine(string.Join(' ', fingering.Skip(1)));
    }

    private enum Direction
    {
        Descending,
        Constant,
        Ascending
    }
}
