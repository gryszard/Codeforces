using Codeforces.Utilities;

namespace Codeforces._1898;

public class B_Milena_and_Admirer(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var n = FetchSingleInt();
        var nextLine = _textReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(nextLine);

        if (n == 1)
        {
            _textWriter.WriteLine(0);
            return;
        }

        var arrayAsText = new ArrayAsText(nextLine);

        var lastToken = arrayAsText.PopLastArrayElement();
        long totalOperations = 0;

        for (int i = n - 2; i >= 0; i--)
        {
            var currentToken = arrayAsText.PopLastArrayElement();
            var newOperations = (currentToken - 1) / lastToken;
            lastToken = currentToken;

            if (newOperations == 0)
            {
                continue;
            }

            totalOperations += newOperations;

            var smallestNewValue = currentToken / (newOperations + 1);
            lastToken = smallestNewValue;
        }

        _textWriter.WriteLine(totalOperations);
    }


    private class ArrayAsText
    {
        private int _currentLength;
        private readonly string _arrayAsText;

        public ArrayAsText(string arrayAsText)
        {
            _arrayAsText = arrayAsText;
            _currentLength = arrayAsText.Length;
        }

        internal int PopLastArrayElement()
        {
            var currentArray = _arrayAsText.AsSpan()[.._currentLength];
            var indexOfLastSeparator = currentArray.LastIndexOf(' ');
            var lastToken = currentArray[(indexOfLastSeparator + 1)..];

            _currentLength = indexOfLastSeparator;

            if (!int.TryParse(lastToken, out int value))
            {
                throw new InvalidOperationException("Cannot parse last array token");
            }

            return value;
        }
    }
}
