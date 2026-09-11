using Codeforces.Utilities;

namespace Codeforces._2260;

public class A_Monocarps_Contest(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var array = FetchTokens(n);

        if (array.Count(x => x == 0) < 2)
        {
            _textWriter.WriteLine(-1);
            return;
        }

        if (array.First() == 0 && array.Last() == 0)
        {
            _textWriter.WriteLine(0);
            return;
        }

        if (array.First() == 0 || array.Last() == 0)
        {
            _textWriter.WriteLine(1);
            return;
        }

        _textWriter.WriteLine(2);
    }
}
