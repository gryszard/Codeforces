namespace Codeforces._1371.C_A_Cookie_for_You;

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

        if (!int.TryParse(nextLine, out var testCases))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        for (int i = 0; i < testCases; i++)
        {
            SingleTest();
        }
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var inputValues = nextLine.Split(' ');

        if (inputValues is null || inputValues.Length != 4)
        {
            throw new ArgumentException("Incorrect input values. Expecting three longs: A B N M.");
        }

        if (!long.TryParse(inputValues[0], out long a) ||
            !long.TryParse(inputValues[1], out long b) ||
            !long.TryParse(inputValues[2], out long n) ||
            !long.TryParse(inputValues[3], out long m))
        {
            throw new ArgumentException("Cannot convert input values to longs.");
        }

        var enoughCookiesForGuests = a + b >= n + m;
        var enoughCookiesForSecondType = Math.Min(a, b) >= m;

        if (enoughCookiesForGuests && enoughCookiesForSecondType)
        {
            _textWriter.WriteLine("Yes");
        }
        else
        {
            _textWriter.WriteLine("No");
        }
    }
}
