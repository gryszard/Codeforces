using Codeforces.Utilities;

namespace Codeforces._1253;

public class B_Silly_Mistake(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var events = FetchTokens(n);
        var days = new List<int>();
        var currentDay = new Dictionary<int, bool>();
        var currentWorkersCount = 0;
        var currentEventsCount = 0;

        foreach (var e in events)
        {
            currentEventsCount++;
            bool hasFinishedWork;

            if (e > 0)
            {
                if (!currentDay.TryGetValue(e, out hasFinishedWork))
                {
                    currentDay.Add(e, false);
                    currentWorkersCount++;
                    continue;
                }

                _textWriter.WriteLine(-1);
                return;
            }

            if (!currentDay.TryGetValue(-e, out hasFinishedWork))
            {
                _textWriter.WriteLine(-1);
                return;
            }

            if (hasFinishedWork)
            {
                _textWriter.WriteLine(-1);
                return;
            }

            currentDay[-e] = true;
            currentWorkersCount--;

            if (currentWorkersCount != 0)
            {
                continue;
            }

            days.Add(currentEventsCount);

            currentDay.Clear();
            currentEventsCount = 0;
        }

        if (currentWorkersCount > 0)
        {
            _textWriter.WriteLine(-1);
            return;
        }

        _textWriter.WriteLine(days.Count);
        _textWriter.WriteLine(string.Join(' ', days));
    }
}
