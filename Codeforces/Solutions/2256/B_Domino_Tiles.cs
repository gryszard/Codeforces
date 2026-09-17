using Codeforces.Utilities;

namespace Codeforces._2256;

public class B_Domino_Tiles(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var s = FetchLine();

        List<(bool ContainsZero, bool ContainsOne, bool ContainsQuestion)> groups = [new(), new(), new(), new()];
        int currentModulo = -1;

        foreach (var c in s)
        {
            currentModulo = (currentModulo + 1) % 4;
            var (ContainsZero, ContainsOne, ContainsQuestion) = groups[currentModulo];

            groups[currentModulo] = c switch
            {
                '0' => (true, ContainsOne, ContainsQuestion),
                '1' => (ContainsZero, true, ContainsQuestion),
                _ => (ContainsZero, ContainsOne, true)
            };
        }

        foreach (var (ContainsZero, ContainsOne, _) in groups)
        {
            if (ContainsZero && ContainsOne)
            {
                _textWriter.WriteLine(0);
                return;
            }
        }

        int possibles = 1;

        for (int i = 0; i < 2; i++)
        {
            if (groups[i].ContainsZero && groups[i].ContainsOne ||
                groups[i + 2].ContainsZero && groups[i + 2].ContainsOne)
            {
                _textWriter.WriteLine(0);
                return;
            }

            if (groups[i].ContainsZero && groups[i + 2].ContainsZero)
            {
                _textWriter.WriteLine(0);
                return;
            }

            if (groups[i].ContainsOne && groups[i + 2].ContainsOne)
            {
                _textWriter.WriteLine(0);
                return;
            }

            if (!groups[i].ContainsZero && !groups[i].ContainsOne && !groups[i + 2].ContainsZero && !groups[i + 2].ContainsOne)
            {
                possibles *= 2;
            }
        }

        _textWriter.WriteLine(possibles);
    }
}
