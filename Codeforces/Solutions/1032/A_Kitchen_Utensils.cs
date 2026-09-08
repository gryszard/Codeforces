using Codeforces.Utilities;

namespace Codeforces._1032;

public class A_Kitchen_Utensils(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var (remainingCount, numberOfGuests) = FetchTwoInts();
        var utensils = FetchTokens(remainingCount);
        var buckets = new int[101];
        var maxUtensilsCount = 0;

        foreach (var ut in utensils)
        {
            buckets[ut]++;
            maxUtensilsCount = Math.Max(maxUtensilsCount, buckets[ut]);
        }

        if (maxUtensilsCount % numberOfGuests != 0)
        {
            maxUtensilsCount = maxUtensilsCount / numberOfGuests * numberOfGuests + numberOfGuests;
        }

        var minimumStolenCount = 0;

        for (int i = 1; i < 101; i++)
        {
            if (buckets[i] > 0)
            {
                minimumStolenCount += maxUtensilsCount - buckets[i];
            }
        }

        _textWriter.WriteLine(minimumStolenCount);
    }
}
