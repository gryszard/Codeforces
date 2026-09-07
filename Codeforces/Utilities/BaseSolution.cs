namespace Codeforces.Utilities;

public abstract class BaseSolution(TextReader textReader, TextWriter textWriter)
{
    protected readonly TextReader _textReader = textReader;
    protected readonly TextWriter _textWriter = textWriter;

    public abstract void RunSolution();

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

    protected int FetchSingleInt()
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        if (!int.TryParse(nextLine, out var value))
        {
            throw new ArgumentException("Cannot parse to int");
        }

        return value;
    }

    protected (int, int) FetchTwoInts()
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != 2)
        {
            throw new ArgumentException($"Incorrect input tokens. Expecting 2 ints separated by single space.");
        }

        if (!int.TryParse(tokens[0], out var value1) ||
            !int.TryParse(tokens[1], out var value2))
        {
            throw new ArgumentException("Cannot parse to int");
        }

        return (value1, value2);
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

    protected List<string> FetchStringTokens(int tokensExpected)
    {
        string? nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        var tokens = nextLine.Split(' ');
        if (tokens is null || tokens.Length != tokensExpected)
        {
            throw new ArgumentException($"Incorrect input tokens. Expecting {tokensExpected} tokens separated by single space.");
        }

        return [.. tokens];
    }
}
