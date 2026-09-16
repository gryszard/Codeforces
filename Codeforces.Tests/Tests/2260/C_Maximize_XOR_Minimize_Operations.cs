using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._2260;

internal class C_Maximize_XOR_Minimize_Operations
{
    [TestCaseSource(nameof(LoadExternalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2260.C_Maximize_XOR_Minimize_Operations(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadExternalCases()
    {
        return Utils.LoadExternalTestCases("2260", "C_Maximize_XOR_Minimize_Operations");
    }
}
