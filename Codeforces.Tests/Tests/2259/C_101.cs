namespace Codeforces.Tests._2259;

internal class C_101
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2259.C_101(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            10
            6
            1 0 -1 0 0 1
            7
            0 -1 0 0 1 0 1
            5
            -1 0 0 -1 0
            4
            0 0 0 0
            1
            -1
            6
            1 0 1 0 0 -1
            7
            0 1 0 0 0 1 0
            6
            -1 -1 -1 -1 -1 -1
            7
            -1 0 1 -1 0 0 1
            3
            -1 0 0
            
            """, """
            1 0 0 0 0 1
            0 1 0 0 1 0 1
            1 0 0 1 0
            0 0 0 0
            1
            1 0 1 0 0 1
            0 1 0 0 0 1 0
            1 0 0 0 0 1
            1 0 1 0 0 0 1
            1 0 0

            """);

        yield return new TestCaseData("""
            7
            5
            -1 -1 -1 -1 -1
            5
            1 -1 -1 -1 -1
            5
            -1 -1 -1 -1 1
            5
            1 -1 -1 -1 1
            5
            -1 -1 -1 0 1
            5
            1 0 -1 -1 -1
            5
            1 0 -1 0 1
            
            """, """
            1 0 0 0 1
            1 0 0 0 1
            1 0 0 0 1
            1 0 0 0 1
            1 0 0 0 1
            1 0 0 0 1
            1 0 0 0 1

            """);
    }
}
