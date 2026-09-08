using Codeforces.Utilities;

namespace Codeforces._1253;

public class A_Single_Push(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
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
