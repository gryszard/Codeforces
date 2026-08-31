namespace Codeforces._1A_Theatre_Square;

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

        var inputValues = nextLine.Split(' ');

        if (inputValues is null || inputValues.Length != 3)
        {
            throw new ArgumentException("Incorrect input values. Expecting three integers: N M A.");
        }

        if (!int.TryParse(inputValues[0], out int n) ||
            !int.TryParse(inputValues[1], out int m) ||
            !int.TryParse(inputValues[2], out int a))
        {
            throw new ArgumentException("Cannot convert input values to ints.");
        }

        long tilesVertically = (n - 1) / a + 1;
        long tilesHorizontally = (m - 1) / a + 1;

        long totalTilesNeeded = tilesVertically * tilesHorizontally;
        _textWriter.WriteLine(totalTilesNeeded);
    }
}
