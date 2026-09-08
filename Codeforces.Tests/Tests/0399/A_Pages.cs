using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._0399;

internal class A_Pages
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0399.A_Pages(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return Utils.OneLinerTest("17 5 2", "<< 3 4 (5) 6 7 >>");
        yield return Utils.OneLinerTest("6 5 2", "<< 3 4 (5) 6");
        yield return Utils.OneLinerTest("6 1 2", "(1) 2 3 >>");
        yield return Utils.OneLinerTest("6 2 2", "1 (2) 3 4 >>");
        yield return Utils.OneLinerTest("9 6 3", "<< 3 4 5 (6) 7 8 9");
        yield return Utils.OneLinerTest("10 6 3", "<< 3 4 5 (6) 7 8 9 >>");
        yield return Utils.OneLinerTest("8 5 4", "1 2 3 4 (5) 6 7 8");
        yield return Utils.OneLinerTest("9 6 4", "<< 2 3 4 5 (6) 7 8 9");
        yield return Utils.OneLinerTest("10 6 4", "<< 2 3 4 5 (6) 7 8 9 10");
        yield return Utils.OneLinerTest("11 6 4", "<< 2 3 4 5 (6) 7 8 9 10 >>");
        yield return Utils.OneLinerTest("3 2 1", "1 (2) 3");
        yield return Utils.OneLinerTest("3 1 1", "(1) 2 >>");
        yield return Utils.OneLinerTest("3 3 1", "<< 2 (3)");
    }
}
