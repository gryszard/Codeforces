using Codeforces.Tests.Utilities;

namespace Codeforces.Tests.TMPL;

internal class Template
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces.TMPL.Solution(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            input
            """, """
            ERROR

            """);
    }

    private static IEnumerable<TestCaseData> LoadExternalCases()
    {
        return Utils.LoadExternalTestCases("TMPL", "Template");
    }
}
