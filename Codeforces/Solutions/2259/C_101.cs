using Codeforces.Utilities;

namespace Codeforces._2259;

public class C_101(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var array = FetchTokens(n);

        for (int i = 0; i < n; i++)
        {
            if (array[i] == 1)
            {
                break;
            }

            if (array[i] == -1)
            {
                array[i] = 1;
                break;
            }
        }

        for (int i = n - 1; i >= 0; i--)
        {
            if (array[i] == 1)
            {
                break;
            }

            if (array[i] == -1)
            {
                array[i] = 1;
                break;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (array[i] == -1)
            {
                array[i] = 0;
            }
        }

        for (int i = 0; i < n - 1; i++)
        {
            _textWriter.Write($"{array[i]} ");
        }

        _textWriter.WriteLine(array.Last());
    }
}
