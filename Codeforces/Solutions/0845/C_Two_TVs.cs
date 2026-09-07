using Codeforces.Utilities;

namespace Codeforces._0845;

public class C_Two_TVs(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();

        var tvShows = new List<(int Start, int End)>();

        for (int i = 0; i < n; i++)
        {
            tvShows.Add(FetchTwoInts());
        }

        tvShows = [.. tvShows.OrderBy(s => s.Start)];

        var firstTvOccupiedBy = -1;
        var secondTvOccupiedBy = -1;

        foreach (var (Start, End) in tvShows)
        {
            if (Start > firstTvOccupiedBy)
            {
                firstTvOccupiedBy = End;
                continue;
            }

            if (Start > secondTvOccupiedBy)
            {
                secondTvOccupiedBy = End;
                continue;
            }

            _textWriter.WriteLine("NO");
            return;
        }

        _textWriter.WriteLine("YES");
    }
}
