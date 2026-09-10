using Codeforces.Utilities;

namespace Codeforces._0123;

public class B_Squares(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var tokens = FetchTokens(6);
        var (a, b, x1, y1, x2, y2) = (tokens[0], tokens[1], tokens[2], tokens[3], tokens[4], tokens[5]);

        var rightK1 = CalculateLowerBound(y1, x1, a);
        var rightK2 = CalculateLowerBound(y2, x2, a);

        var leftK1 = CalculateLowerBound(y1, -x1, b);
        var leftK2 = CalculateLowerBound(y2, -x2, b);

        var rightCrosses = Math.Abs(rightK1 - rightK2);
        var leftCrosses = Math.Abs(leftK1 - leftK2);

        _textWriter.WriteLine(Math.Max(rightCrosses, leftCrosses));
    }
    
    private static long CalculateLowerBound(long a, long b, long c)
    {
        long tmp = a + b;

        if (tmp < 0)
        {
            tmp++;
            tmp -= 2 * c;
        }

        return tmp / (2 * c);
    }
}
