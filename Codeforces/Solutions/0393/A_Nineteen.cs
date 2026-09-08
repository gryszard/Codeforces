using Codeforces.Utilities;

namespace Codeforces._0393;

public class A_Nineteen(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var s = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(s);

        char[] nineteenChars = ['n', 'i', 'e', 't'];
        var occurrences = new Dictionary<char, int>
        {
            { 'n', 0 },
            { 'i', 0 },
            { 'e', 0 },
            { 't', 0 }
        };

        foreach (var c in s)
        {
            if (nineteenChars.Contains(c))
            {
                occurrences[c]++;
            }
        }

        var maximumWords = occurrences['t'];
        maximumWords = Math.Min(maximumWords, occurrences['i']);
        maximumWords = Math.Min(maximumWords, occurrences['e'] / 3);
        maximumWords = Math.Min(maximumWords, (occurrences['n'] - 1) / 2);

        _textWriter.WriteLine(maximumWords);
    }
}
