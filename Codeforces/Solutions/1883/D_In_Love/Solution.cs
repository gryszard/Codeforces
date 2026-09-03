using Codeforces.Utilities;

namespace Codeforces._1883.D_In_Love;

public class Solution(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine, out var operationsCount))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        for (int i = 0; i < operationsCount; i++)
        {
            ModifyMultiset();
        }
    }

    private record Location(int Left, int Right);
    private readonly Dictionary<Location, int> multiset = [];

    private static readonly Location DefaultSegment = new(1, (int)1e9);
    private Location MostlyLeftSegment = DefaultSegment;
    private Location MostlyRightSegment = DefaultSegment;
    private string CurrentAnswer => Intersects(MostlyLeftSegment, MostlyRightSegment) ? "NO" : "YES";

    private void ModifyMultiset()
    {
        var tokens = FetchStringTokens(3);

        if (!int.TryParse(tokens[1], out int segmentStart) ||
            !int.TryParse(tokens[2], out int segmentEnd))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        if (tokens[0] == "+")
        {
            AddSegmentAndCheck(segmentStart, segmentEnd);
        }
        if (tokens[0] == "-")
        {
            RemoveSegmentAndCheck(segmentStart, segmentEnd);
        }
    }

    private void AddSegmentAndCheck(int segmentStart, int segmentEnd)
    {
        var location = new Location(segmentStart, segmentEnd);

        if (multiset.TryGetValue(location, out var count))
        {
            multiset[location] = count + 1;
            _textWriter.WriteLine(CurrentAnswer);
            return;
        }

        multiset.Add(location, 1);

        if (segmentEnd < MostlyLeftSegment.Right)
        {
            MostlyLeftSegment = location;
        }
        if (segmentStart > MostlyRightSegment.Left)
        {
            MostlyRightSegment = location;
        }

        _textWriter.WriteLine(CurrentAnswer);
    }

    private void RemoveSegmentAndCheck(int segmentStart, int segmentEnd)
    {
        var location = new Location(segmentStart, segmentEnd);

        if (!multiset.TryGetValue(location, out var count))
        {
            throw new InvalidOperationException($"Segment ({segmentStart}, {segmentEnd}) to be removed does not exist in dictionary");
        }

        if (count > 1)
        {
            multiset[location] = count - 1;
            _textWriter.WriteLine(CurrentAnswer);
            return;
        }

        multiset.Remove(location);

        if (location == MostlyLeftSegment)
        {
            MostlyLeftSegment = DefaultSegment;

            foreach (var key in multiset.Keys)
            {
                if (key.Right < MostlyLeftSegment.Right)
                {
                    MostlyLeftSegment = key;
                }
            }
        }

        if (location == MostlyRightSegment)
        {
            MostlyRightSegment = DefaultSegment;

            foreach (var key in multiset.Keys)
            {
                if (key.Left > MostlyRightSegment.Left)
                {
                    MostlyRightSegment = key;
                }
            }
        }

        _textWriter.WriteLine(CurrentAnswer);
    }

    private static bool Intersects(Location left, Location right)
    {
        return left.Right >= right.Left;
    }
}
