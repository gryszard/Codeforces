namespace Codeforces._1114.A_Got_Any_Grapes;

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
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != 3)
        {
            throw new ArgumentException("Incorrect input values. Expecting three integers: X Y Z.");
        }

        if (!int.TryParse(tokens[0], out int x) ||
            !int.TryParse(tokens[1], out int y) ||
            !int.TryParse(tokens[2], out int z))
        {
            throw new ArgumentException("Cannot convert input values to ints.");
        }

        nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != 3)
        {
            throw new ArgumentException("Incorrect input values. Expecting three integers: A B C.");
        }

        if (!int.TryParse(tokens[0], out int a) ||
            !int.TryParse(tokens[1], out int b) ||
            !int.TryParse(tokens[2], out int c))
        {
            throw new ArgumentException("Cannot convert input values to ints.");
        }

        var enoughGrapesForAndrew = a >= x;
        var enoughGrapesForDmitry = a + b >= x + y;
        var enoughGrapesForMichal = a + b + c >= x + y + z;

        if (enoughGrapesForAndrew && enoughGrapesForDmitry && enoughGrapesForMichal)
        {
            _textWriter.WriteLine("YES");
        }
        else
        {
            _textWriter.WriteLine("NO");
        }
    }
}
