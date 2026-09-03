using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._1883;

internal class D_In_Love
{
    [TestCaseSource(nameof(LoadExternalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1883.D_In_Love.Solution(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadExternalCases()
    {
        return Utils.LoadExternalTestCases("1883", "D_In_Love");
    }
}
