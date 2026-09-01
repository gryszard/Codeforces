namespace Codeforces.Tests._1133;

internal class A_Middle_of_the_Contest
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1133.A_Middle_of_the_Contest.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            10:00
            11:00
            
            """, """
            10:30

            """);

        yield return new TestCaseData("""
            11:10
            11:12
            
            """, """
            11:11

            """);

        yield return new TestCaseData("""
            01:02
            03:02
            
            """, """
            02:02

            """);

        yield return new TestCaseData("""
            00:00
            23:58
            
            """, """
            11:59

            """);

        yield return new TestCaseData("""
            00:00
            00:02
            
            """, """
            00:01

            """);

        yield return new TestCaseData("""
            09:59
            10:03
            
            """, """
            10:01

            """);
    }
}
