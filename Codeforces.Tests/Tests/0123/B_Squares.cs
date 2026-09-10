using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._0123;

internal class B_Squares
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0123.B_Squares(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return Utils.OneLinerTest("2 2 1 0 0 1", "1");
        yield return Utils.OneLinerTest("2 2 10 11 0 1", "5");
        yield return Utils.OneLinerTest("2 4 3 -1 3 7", "2");
    }
}
