namespace Codeforces._1720.C_Corners;

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
        var tokens = FetchTokens(2);
        (var n, var m) = (tokens[0], tokens[1]);
        var matrixType = MatrixType.NoZeros;
        var onesCount = 0;

        string? previousLine = new('1', m);

        for (int i = 0; i < n; i++)
        {
            var currentLine = _textReader.ReadLine();
            ArgumentException.ThrowIfNullOrWhiteSpace(currentLine);

            // Shortcut if we already decided that there are adjacent zeros.
            if (matrixType == MatrixType.AdjacentZeros)
            {
                onesCount += currentLine.Count(c => c == '1');
                previousLine = currentLine;
                continue;
            }

            for (int j = 0; j < m; j++)
            {
                if (currentLine[j] == '1')
                {
                    onesCount++;
                    continue;
                }

                if (matrixType == MatrixType.AdjacentZeros)
                {
                    continue;
                }

                matrixType = MatrixType.SingleZeros;

                // Looking for adjacent zeros.
                // Top left cell
                if (j >= 1 && previousLine[j - 1] == '0')
                {
                    matrixType = MatrixType.AdjacentZeros;
                    continue;
                }

                // Top cell
                if (previousLine[j] == '0')
                {
                    matrixType = MatrixType.AdjacentZeros;
                    continue;
                }

                // Top right cell
                if (j + 1 < m && previousLine[j + 1] == '0')
                {
                    matrixType = MatrixType.AdjacentZeros;
                    continue;
                }

                // Left cell
                if (j >= 1 && currentLine[j - 1] == '0')
                {
                    matrixType = MatrixType.AdjacentZeros;
                    continue;
                }
            }

            previousLine = currentLine;
        }

        if (matrixType == MatrixType.SingleZeros)
        {
            onesCount -= 1;
        }
        else if (matrixType == MatrixType.NoZeros)
        {
            onesCount -= 2;
        }

        _textWriter.WriteLine(onesCount);
    }

    private enum MatrixType
    {
        NoZeros,
        SingleZeros,
        AdjacentZeros
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
