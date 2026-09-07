namespace Codeforces.Tests._0710;

internal class A_King_Moves
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0710.A_King_Moves(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return OneLinerTest("a1", "3");
        yield return OneLinerTest("a8", "3");
        yield return OneLinerTest("h1", "3");
        yield return OneLinerTest("h8", "3");

        yield return OneLinerTest("a2", "5");
        yield return OneLinerTest("a3", "5");
        yield return OneLinerTest("a4", "5");
        yield return OneLinerTest("a5", "5");
        yield return OneLinerTest("a6", "5");
        yield return OneLinerTest("a7", "5");

        yield return OneLinerTest("b1", "5");
        yield return OneLinerTest("b8", "5");
        yield return OneLinerTest("c1", "5");
        yield return OneLinerTest("c8", "5");
        yield return OneLinerTest("d1", "5");
        yield return OneLinerTest("d8", "5");
        yield return OneLinerTest("e1", "5");
        yield return OneLinerTest("e8", "5");
        yield return OneLinerTest("f1", "5");
        yield return OneLinerTest("f8", "5");
        yield return OneLinerTest("g1", "5");
        yield return OneLinerTest("g8", "5");

        yield return OneLinerTest("h2", "5");
        yield return OneLinerTest("h3", "5");
        yield return OneLinerTest("h4", "5");
        yield return OneLinerTest("h5", "5");
        yield return OneLinerTest("h6", "5");
        yield return OneLinerTest("h7", "5");

        yield return OneLinerTest("b2", "8");
        yield return OneLinerTest("b7", "8");
        yield return OneLinerTest("g2", "8");
        yield return OneLinerTest("g7", "8");

        yield return OneLinerTest("b4", "8");
        yield return OneLinerTest("c3", "8");
        yield return OneLinerTest("d6", "8");
        yield return OneLinerTest("e2", "8");
        yield return OneLinerTest("f7", "8");
        yield return OneLinerTest("g5", "8");
    }

    private static TestCaseData OneLinerTest(string input, string expectedOutput)
    {
        return new TestCaseData(input, expectedOutput + Environment.NewLine);
    }
}
