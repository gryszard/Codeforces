using Codeforces.Utilities;

namespace Codeforces._1119;

public class A_Ilya_and_a_Colorful_Walk(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var colors = FetchTokens(n);
        var firstColor = colors.First();
        var lastColor = colors.Last();

        if (firstColor != lastColor)
        {
            _textWriter.WriteLine(n - 1);
            return;
        }

        int maximumDistance = 0;
        for (int i = n - 2; i > 0; i--)
        {
            if (firstColor != colors[i])
            {
                maximumDistance = i;
                break;
            }
        }

        for (int i = 1; i < n - 1; i++)
        {
            if (colors[i] != lastColor)
            {
                maximumDistance = Math.Max(maximumDistance, n - 1 - i);
                break;
            }
        }

        _textWriter.WriteLine(maximumDistance);
    }
}
