namespace Codeforces.Tests._0352;

internal class B_Jeff_and_Periods
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0352.B_Jeff_and_Periods.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            1
            2
            
            """, """
            1
            2 0
            
            """);

        yield return new TestCaseData("""
            8
            1 2 1 3 1 2 1 5
            
            """, """
            4
            1 2
            2 4
            3 0
            5 0
            
            """);

        yield return new TestCaseData("""
            5
            100000 100000 100000 100000 100000
            
            """, """
            1
            100000 1
            
            """);

        yield return new TestCaseData("""
            6
            1 2 1 1 2 2
            
            """, """
            0
            
            """);
    }
}
