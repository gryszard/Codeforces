using Codeforces.Utilities;

namespace Codeforces._1133;

public class B_Preparation_for_International_Womens_Day(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var (n, k) = FetchTwoInts();
        var candies = FetchTokens(n);
        var buckets = new int[100];

        foreach (var cand in candies)
        {
            buckets[cand % k]++;
        }

        int i, j;
        var giftsCount = buckets[0] / 2;

        for (i = 1, j = k - 1; i <= j; i++, j--)
        {
            if (i == j)
            {
                giftsCount += buckets[i] / 2;
            }
            else
            {
                giftsCount += Math.Min(buckets[i], buckets[j]);
            }
        }

        _textWriter.WriteLine(giftsCount * 2);
    }
}
