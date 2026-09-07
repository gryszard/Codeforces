using Codeforces.Utilities;

namespace Codeforces._2189;

public class C1_XOR_Convenience(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();

        _textWriter.Write($"{n / 2 * 2}");

        int i;
        for (i = 2; i + 2 <= n; i += 2)
        {
            _textWriter.Write($" {i + 1} {i}");
        }

        if (n % 2 == 1)
        {
            _textWriter.Write($" {n}");
        }

        _textWriter.WriteLine($" 1");
    }
}
