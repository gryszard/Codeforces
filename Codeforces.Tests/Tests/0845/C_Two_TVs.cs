namespace Codeforces.Tests._0845;

internal class C_Two_TVs
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0845.C_Two_TVs(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            3
            1 2
            2 3
            4 5
            
            """, """
            YES

            """);

        yield return new TestCaseData("""
            4
            1 2
            2 3
            2 3
            1 2
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            8
            1 2
            3 4
            5 6
            7 8
            2 3
            4 5
            6 7
            8 9
            
            """, """
            YES

            """);

        yield return new TestCaseData("""
            8
            1 2
            3 4
            5 6
            7 8
            2 3
            3 5
            6 7
            8 9
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            9
            1 2
            3 4
            5 6
            7 8
            2 3
            4 5
            6 7
            8 9
            2 3
            
            """, """
            NO

            """);
    }
}
