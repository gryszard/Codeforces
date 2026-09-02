namespace Codeforces._0071.A_Way_Too_Long_Words;

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

        if (!int.TryParse(nextLine, out var linesCount))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        if (linesCount < 1 || linesCount > 100)
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        for (int i = 0; i < linesCount; i++)
        {
            nextLine = _textReader.ReadLine();

            if (nextLine is null || nextLine.Length < 1 || nextLine.Length > 100)
            {
                _textWriter.WriteLine("ERROR");
                return;
            }

            if (nextLine.Length <= 10)
            {
                _textWriter.WriteLine(nextLine);
                continue;
            }

            _textWriter.WriteLine($"{nextLine.First()}{nextLine.Length - 2}{nextLine.Last()}");
        }
    }
}
