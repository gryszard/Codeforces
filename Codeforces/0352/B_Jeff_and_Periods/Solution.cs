namespace Codeforces._0352.B_Jeff_and_Periods;

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
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine, out var arrayLength))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        var array = FetchTokens(arrayLength);
        var periods = new SortedDictionary<int, Period>();

        for (int i = 0; i < arrayLength; i++)
        {
            var number = array[i];

            if (!periods.TryGetValue(number, out Period? period))
            {
                period = new Period { LastOccurrence = i };
                periods.Add(number, period);
                continue;
            }

            var indexDifference = i - period.LastOccurrence;
            period.LastOccurrence = i;

            if (period.Progression == 0)
            {
                period.Progression = indexDifference;
                continue;
            }
            
            if (period.Progression != indexDifference)
            {
                period.IsFailed = true;
            }
        }

        var periodsCount = periods.Where(kv => !kv.Value.IsFailed).Count();
        _textWriter.WriteLine(periodsCount);

        foreach (var key in periods.Keys)
        {
            var period = periods[key];

            if (period.IsFailed)
            {
                continue;
            }

            _textWriter.WriteLine($"{key} {period.Progression}");
        }
    }

    private class Period
    {
        public int Progression { get; set; } = 0;
        public int LastOccurrence { get; set; }
        public bool IsFailed { get; set; } = false;
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
