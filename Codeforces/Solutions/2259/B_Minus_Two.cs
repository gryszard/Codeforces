using Codeforces.Utilities;

namespace Codeforces._2259;

public class B_Minus_Two(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var array = FetchTokens(n);

        var divisor = 4;
        int[] modulosCount = new int[divisor];

        foreach (var token in array)
        {
            modulosCount[token % divisor]++;
        }

        var oddsCount = modulosCount[1] + modulosCount[3];
        var quattrosCount = modulosCount[0];
        var twosCount = modulosCount[2];

        var maximumGroupCount = Math.Max(oddsCount, Math.Max(quattrosCount, twosCount));

        _textWriter.WriteLine(maximumGroupCount);
    }
}
