namespace Codeforces.Tests._1133;

internal class B_Preparation_for_International_Womens_Day
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1133.B_Preparation_for_International_Womens_Day(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            7 2
            1 2 2 3 2 4 10
            
            """, """
            6

            """);

        yield return new TestCaseData("""
            8 2
            1 2 2 3 2 4 6 10
            
            """, """
            8

            """);

        yield return new TestCaseData("""
            7 3
            1 2 2 3 2 4 5
            
            """, """
            4

            """);

        yield return new TestCaseData("""
            5 5
            5 20 1000 999999990 999999995
            
            """, """
            4

            """);

        yield return new TestCaseData("""
            5 5
            1 6 11 16 19
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            5 5
            2 8 13 18 23
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            6 5
            2 7 3 13 23 27
            
            """, """
            6

            """);
    }
}
