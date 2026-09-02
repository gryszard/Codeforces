namespace Codeforces.Tests._1114;

internal class A_Got_Any_Grapes
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1114.A_Got_Any_Grapes.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            1 6 2
            4 3 3
            
            """, """
            YES

            """);

        yield return new TestCaseData("""
            5 1 1
            4 3 2
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            100000 100000 100000
            100000 100000 99999
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            100000 100000 99999
            100000 99999 100000
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            100000 100000 99999
            99999 100000 100000
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            100000 100000 100000
            100000 100000 100000
            
            """, """
            YES

            """);
    }
}
