namespace Codeforces._0688.A_Opponents;

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
        var tokens = FetchTokens(2);
        var d = tokens[1];

        var longestSeries = 0;
        var currentSeries = 0;

        for (int i = 0; i < d; i++)
        {
            string? nextLine = _textReader.ReadLine();
            ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

            if (nextLine.Contains('0'))
            {
                currentSeries++;
                continue;
            }

            longestSeries = Math.Max(longestSeries, currentSeries);
            currentSeries = 0;
        }

        longestSeries = Math.Max(longestSeries, currentSeries);

        _textWriter.WriteLine(longestSeries);
    }
}

public class BaseSolution(TextReader textReader, TextWriter textWriter)
{
    protected readonly TextReader _textReader = textReader;
    protected readonly TextWriter _textWriter = textWriter;

    protected List<int> FetchTokens(int tokensExpected)
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != tokensExpected)
        {
            throw new ArgumentException($"Incorrect input tokens. Expecting {tokensExpected} tokens separated by single space.");
        }

        return [.. tokens.Select(int.Parse)];
    }
}
