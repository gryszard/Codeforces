namespace Codeforces._1133.A_Middle_of_the_Contest;

public static class Program
{
    public static void Main()
    {
        var solution = new Solution(Console.In, Console.Out);
        solution.Run();
    }
}

public class Solution
{
    private readonly TextReader _textReader;
    private readonly TextWriter _textWriter;

    public Solution()
    {
        _textReader = Console.In;
        _textWriter = Console.Out;
    }

    public Solution(TextReader textReader, TextWriter textWriter)
    {
        _textReader = textReader;
        _textWriter = textWriter;
    }

    public void Run()
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
