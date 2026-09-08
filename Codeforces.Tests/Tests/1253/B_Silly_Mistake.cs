namespace Codeforces.Tests._1253;

internal class B_Silly_Mistake
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1253.B_Silly_Mistake(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            6
            1 7 -7 3 -1 -3
            
            """, """
            1
            6

            """);

        yield return new TestCaseData("""
            8
            1 -1 1 2 -1 -2 3 -3
            
            """, """
            3
            2 4 2

            """);

        yield return new TestCaseData("""
            6
            2 5 -5 5 -5 -2
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            3
            -8 1 1
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            3
            1 1 -1
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            3
            1 -1 -1
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            2
            -1 1
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            1
            1
            
            """, """
            -1

            """);

        yield return new TestCaseData("""
            12
            1 2 3 4 5 6 -6 -5 -4 -3 -2 -1
            
            """, """
            1
            12

            """);

        yield return new TestCaseData("""
            10
            1000000 999999 -1000000 999998 -999998 -999999 999997 999996 -999996 -999997
            
            """, """
            2
            6 4

            """);
    }
}
