using Codeforces.Utilities;

namespace Codeforces._2013;

public class C_Password_Cracking(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        _textWriter.WriteLine();
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();
        while (string.IsNullOrEmpty(nextLine))
        {
            nextLine = _textReader.ReadLine();
        }

        if (!int.TryParse(nextLine, out BinaryStringSize))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        CurrentSubstring = string.Empty;
        AddingPrefix = true;

        var queryLimit = 2 * BinaryStringSize;
        for (int i = 0; i < queryLimit; i++)
        {
            ExtendSubstring();

            if (CurrentSubstring.Length == BinaryStringSize)
            {
                _textWriter.WriteLine();
                _textWriter.WriteLine($"! {CurrentSubstring}");
                return;
            }
        }
    }

    private void ExtendSubstring()
    {
        string testedSubstring;
        int isSubstring;

        if (AddingPrefix)
        {
            testedSubstring = '1' + CurrentSubstring;
            isSubstring = SendQueryAndGetResult(testedSubstring);

            if (isSubstring == 1)
            {
                CurrentSubstring = testedSubstring;
                return;
            }

            testedSubstring = '0' + CurrentSubstring;
            isSubstring = SendQueryAndGetResult(testedSubstring);

            if (isSubstring == 1)
            {
                CurrentSubstring = testedSubstring;
                return;
            }

            AddingPrefix = false;
            return;
        }


        testedSubstring = CurrentSubstring + '1';
        isSubstring = SendQueryAndGetResult(testedSubstring);

        if (isSubstring == 1)
        {
            CurrentSubstring = testedSubstring;
            return;
        }

        CurrentSubstring += '0';
    }

    private int SendQueryAndGetResult(string queriedSubstring)
    {
        _textWriter.WriteLine();
        _textWriter.WriteLine($"? {queriedSubstring}");

        var answer = _textReader.ReadLine();
        while (string.IsNullOrEmpty(answer))
        {
            answer = _textReader.ReadLine();
        }

        if (!int.TryParse(answer, out var isSubstring))
        {
            _textWriter.WriteLine("Error in parsing query answer");
            return 0;
        }

        if (isSubstring == -1)
        {
            Environment.FailFast("Number of queries exceeded");
        }

        return isSubstring;
    }

    private string CurrentSubstring = string.Empty;
    private bool AddingPrefix;
    private int BinaryStringSize;
}
