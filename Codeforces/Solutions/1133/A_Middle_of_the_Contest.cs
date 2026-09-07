using Codeforces.Utilities;

namespace Codeforces._1133;

public class A_Middle_of_the_Contest(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine.AsSpan()[..2], out var h1) ||
            !int.TryParse(nextLine.AsSpan()[^2..], out var m1))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine.AsSpan()[..2], out var h2) ||
            !int.TryParse(nextLine.AsSpan()[^2..], out var m2))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        var differenceInMinutes = (60 * h2 + m2) - (60 * h1 + m1);
        var minutesToMiddle = differenceInMinutes / 2;
        (var hMiddle, var mMiddle) = (h1, m1 + minutesToMiddle);

        if (mMiddle > 59)
        {
            hMiddle += mMiddle / 60;
            mMiddle %= 60;
        }

        _textWriter.WriteLine($"{hMiddle:00}:{mMiddle:00}");
    }
}
