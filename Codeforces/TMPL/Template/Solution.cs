using Codeforces.Utilities;

namespace Codeforces.TMPL.Template;

public class Solution(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        string? nextLine = _textReader.ReadLine();

        if (!int.TryParse(nextLine, out var _))
        {
            _textWriter.WriteLine("ERROR");
            return;
        }

        // TODO: Implement the rest of the logic.
    }
}
