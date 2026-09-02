namespace Codeforces._1253.A_Single_Push;

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

        var arrayA = FetchTokens(arrayLength);
        var arrayB = FetchTokens(arrayLength);

        LoopArrays(arrayA, arrayB, arrayLength);
    }

    private void LoopArrays(List<int> arrayA, List<int> arrayB, int arrayLength)
    {
        var intervalStarted = false;
        var intervalFinished = false;
        var expectedK = 0;

        for (int i = 0; i < arrayLength; i++)
        {
            if (arrayA[i] > arrayB[i])
            {
                _textWriter.WriteLine("NO");
                return;
            }

            if (!intervalStarted && arrayA[i] == arrayB[i])
            {
                continue;
            }

            if (!intervalStarted && arrayA[i] < arrayB[i])
            {
                intervalStarted = true;
                expectedK = arrayB[i] - arrayA[i];
                continue;
            }

            // From now on intervalStarted == true

            if (arrayA[i] == arrayB[i])
            {
                intervalFinished = true;
                continue;
            }

            // From now on arrayA[i] < arrayB[i]

            if (intervalFinished)
            {
                _textWriter.WriteLine("NO");
                return;
            }

            if (expectedK != arrayB[i] - arrayA[i])
            {
                _textWriter.WriteLine("NO");
                return;
            }
        }

        _textWriter.WriteLine("YES");
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