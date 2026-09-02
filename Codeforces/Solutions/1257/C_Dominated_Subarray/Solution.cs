namespace Codeforces._1257.C_Dominated_Subarray;

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
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine, out var arrayLength))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        var array = FetchTokens(arrayLength);
        var lastIndexes = new Dictionary<int, int>();
        var shortestSubarray = int.MaxValue;

        for (int i = 0; i < arrayLength; i++)
        {
            var value = array[i];

            if (!lastIndexes.TryGetValue(value, out int lastIndex))
            {
                lastIndexes.Add(value, i);
                continue;
            }

            var indexDifference = i - lastIndex;
            shortestSubarray = Math.Min(shortestSubarray, indexDifference + 1);

            lastIndexes[value] = i;
        }

        if (shortestSubarray == int.MaxValue)
        {
            shortestSubarray = -1;
        }

        _textWriter.WriteLine(shortestSubarray);
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
