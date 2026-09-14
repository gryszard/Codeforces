using Codeforces.Utilities;
using System.Text;

namespace Codeforces._2259;

public class D_MEX_Multiset(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var array = FetchTokens(n);

        var zerosCount = 0;
        var stringBuilder = new StringBuilder();

        foreach (var token in array)
        {
            if (token == 0)
            {
                zerosCount++;

                if (zerosCount == 1)
                {
                    stringBuilder.Append('A');
                    continue;
                }

                stringBuilder.Append('B');
                continue;
            }

            stringBuilder.Append('C');
        }

        if (zerosCount == 1)
        {
            _textWriter.WriteLine("NO");
            return;
        }

        _textWriter.WriteLine("YES");
        _textWriter.WriteLine(stringBuilder.ToString());
    }
}
