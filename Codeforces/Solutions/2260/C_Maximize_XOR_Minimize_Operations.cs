using Codeforces.Utilities;

namespace Codeforces._2260;

public class C_Maximize_XOR_Minimize_Operations(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var span = _textReader.ReadLine().AsSpan();
        List<long> tokens = [];

        foreach (var range in span.Split(' '))
        {
            var start = range.Start.Value;
            int length = range.End.Value - start;
            tokens.Add(long.Parse(span.Slice(start, length)));
        }

        var (x, y) = (tokens[0], tokens[1]);
        long maxPossible = x + y;
        long currentPower = 1;

        while (currentPower < maxPossible)
        {
            currentPower *= 2;
        }

        long max = maxPossible;

        while (currentPower > 0)
        {
            long xPart = x / currentPower;
            long yPart = y / currentPower;
            long maxPart = max / currentPower;

            x %= currentPower;
            y %= currentPower;
            max %= currentPower;

            if ((xPart ^ yPart) != maxPart)
            {
                _textWriter.WriteLine($"{maxPossible} {currentPower - y}");
                return;
            }

            currentPower /= 2;
        }

        _textWriter.WriteLine($"{maxPossible} 0");
        return;
    }
}
