namespace Codeforces._1371.B_Magical_Calendar;

public static class Program
{
    public static void Main()
    {
        var solution = new Solution(Console.In, Console.Out);
        solution.Run();
    }
}

public class Solution(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public void Run()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        (var n, var r) = FetchTokens(2);

        long result;

        if (n > r)
        {
            result = r * (r + 1) / 2;
        }
        else
        {
            result = n * (n - 1) / 2 + 1;
        }

        _textWriter.WriteLine(result);
    }
}

public class BaseSolution(TextReader textReader, TextWriter textWriter)
{
    protected readonly TextReader _textReader = textReader;
    protected readonly TextWriter _textWriter = textWriter;

    protected void RunTests(Action singleTest)
    {
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine, out var testCases))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        for (int i = 0; i < testCases; i++)
        {
            singleTest();
        }
    }

    protected (long n, long r) FetchTokens(int tokensExpected)
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != tokensExpected)
        {
            throw new ArgumentException($"Incorrect input tokens. Expecting {tokensExpected} tokens separated by single space.");
        }

        return (long.Parse(tokens[0]), long.Parse(tokens[1]));
    }
}
