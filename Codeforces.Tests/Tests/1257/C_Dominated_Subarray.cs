using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._1257;

public class C_Dominated_Subarray
{
    [TestCaseSource(nameof(LoadCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1257.C_Dominated_Subarray.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadCases()
    {
        return Utils.LoadExternalTestCases("1257", "C_Dominated_Subarray");
    }
}
