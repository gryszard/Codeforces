namespace Codeforces.Tests._2260;

internal class A_Monocarps_Contest
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2260.A_Monocarps_Contest(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            4
            2
            0 0
            2
            0 1
            6
            1 0 0 1 0 0
            5
            1 0 0 1 1
            
            """, """
            0
            -1
            1
            2

            """);
    }
}
