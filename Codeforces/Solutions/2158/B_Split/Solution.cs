namespace Codeforces._2158.B_Split;

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

        if (!int.TryParse(nextLine, out var n))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        Solve(n);
    }

    private void Solve(int n)
    {
        var array = FetchTokens(2 * n);
        var counts = new Dictionary<int, int>();

        foreach (var token in array)
        {
            if (!counts.TryGetValue(token, out int valueCount))
            {
                counts.Add(token, 1);
                continue;
            }

            counts[token] = valueCount + 1;
        }

        var remainingSpaceLeft = n;
        var remainingSpaceRight = n;
        var oddCountsHappened = false;
        var result = 0;
        foreach (var key in counts.OrderByDescending(kv => kv.Value).Select(kv => kv.Key))
        {
            var keyCount = counts[key];

            var isCountOdd = keyCount % 2 == 1;
            var isFinisher = keyCount == remainingSpaceLeft + remainingSpaceRight;

            var smallerSpace = Math.Min(remainingSpaceLeft, remainingSpaceRight);
            if (smallerSpace == 0)
            {
                smallerSpace = Math.Max(remainingSpaceLeft, remainingSpaceRight);
            }
            var isSmallerSpaceEvened = smallerSpace % 2 == 0;

            if (isFinisher && isCountOdd)
            {
                result += 1;
                _textWriter.WriteLine(result);
                return;
            }

            if (isFinisher && !isSmallerSpaceEvened)
            {
                result += 2;
                _textWriter.WriteLine(result);
                return;
            }

            if (isFinisher && oddCountsHappened)
            {
                result += 2;
                _textWriter.WriteLine(result);
                return;
            }

            if (isFinisher)
            {
                _textWriter.WriteLine(result);
                return;
            }

            var spaceTaken = keyCount / 2;

            if (isCountOdd)
            {
                oddCountsHappened = true;
                remainingSpaceLeft -= spaceTaken;
                remainingSpaceRight -= spaceTaken;

                if (remainingSpaceLeft < remainingSpaceRight)
                {
                    remainingSpaceRight -= 1;
                }
                else
                {
                    remainingSpaceLeft -= 1;
                }

                result += 1;
                continue;
            }

            if (keyCount % 4 == 0)
            {
                remainingSpaceLeft -= spaceTaken;
                remainingSpaceRight -= spaceTaken;

                if (remainingSpaceLeft < remainingSpaceRight)
                {
                    remainingSpaceLeft += 1;
                    remainingSpaceRight -= 1;
                }
                else
                {
                    remainingSpaceLeft -= 1;
                    remainingSpaceRight += 1;
                }

                result += 2;
                continue;
            }

            remainingSpaceLeft -= spaceTaken;
            remainingSpaceRight -= spaceTaken;
            result += 2;
        }
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
