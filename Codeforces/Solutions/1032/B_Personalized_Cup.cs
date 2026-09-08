using Codeforces.Utilities;

namespace Codeforces._1032;

public class B_Personalized_Cup(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var s = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(s);

        var length = s.Length;
        var rows = (length - 1) / 20 + 1;
        var columns = (length - 1) / rows + 1;
        var stars = rows * columns - length;
        var noStars = rows - stars;

        _textWriter.WriteLine($"{rows} {columns}");

        for (int i = 0; i < noStars; i++)
        {
            var start = i * columns;
            var rowLength = columns;

            _textWriter.WriteLine(s.AsSpan().Slice(start, rowLength));
        }

        var offset = noStars * columns;
        for (int i = 0; i < stars; i++)
        {
            var start = offset + i * columns - i;
            var rowLength = columns - 1;

            _textWriter.WriteLine($"{s.AsSpan().Slice(start, rowLength)}*");
        }
    }
}
