using Codeforces.Utilities;
using System.Text;

namespace Codeforces._0399;

public class A_Pages(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var (n, p, k) = FetchThreeInts();
        var stringBuilder = new StringBuilder();

        if (p - k > 1)
        {
            stringBuilder.Append("<< ");
        }

        var leftStart = Math.Max(1, p - k);
        for (int i = leftStart; i < p; i++)
        {
            stringBuilder.Append($"{i} ");
        }

        stringBuilder.Append($"({p}) ");

        var rightEnd = Math.Min(n, p + k);
        for (int i = p + 1; i <= rightEnd; i++)
        {
            stringBuilder.Append($"{i} ");
        }

        if (p + k < n)
        {
            stringBuilder.Append(">>");
        }
        else
        {
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
        }

        _textWriter.WriteLine(stringBuilder.ToString());
    }
}
