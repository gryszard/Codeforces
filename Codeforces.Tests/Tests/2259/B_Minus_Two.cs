namespace Codeforces.Tests._2259;

internal class B_Minus_Two
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2259.B_Minus_Two(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            5
            2
            1 3
            4
            1 1 1 2
            3
            6 7 8
            4
            2 2 2 2
            5
            1 10 100 1000 100000
            
            """, """
            2
            3
            1
            4
            3

            """);

        yield return new TestCaseData("""
            6
            10
            1 99 99999 9999999 99999999 999999999 2 4 6 8
            10
            2 98 99998 9999998 99999998 999999998 1 3 4 8
            10
            4 96 99996 9999996 99999996 1000000000 1 3 2 6
            10
            1 1 1 1 1 1 1 1 1 1
            10
            2 2 2 2 2 2 2 2 2 2
            10
            4 4 4 4 4 4 4 4 4 4
            
            """, """
            6
            6
            6
            10
            10
            10

            """);
    }
}
