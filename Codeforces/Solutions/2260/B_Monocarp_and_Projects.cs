using Codeforces.Utilities;

namespace Codeforces._2260;

public class B_Monocarp_and_Projects(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var tokens = FetchLongTokens(3);
        var (x, y, k) = (tokens[0], tokens[1], tokens[2]);

        var (currX, currY, currK) = (x, y, k);
        long sum = 0;

        while (currK > 0)
        {
            var divisor = currY / currX;
            var modulo = currY % currX;

            if (divisor == 1)
            {
                sum += currK * modulo;
                break;
            }

            var counts = Math.Min(modulo / (divisor - 1) + 1, currK);
            var first = modulo - (counts - 1) * (divisor - 1);
            var last = modulo;

            sum += (first + last) * counts / 2;

            currX += counts;
            currY += counts;
            currK -= counts;
        }

        _textWriter.WriteLine(sum);
    }
}
