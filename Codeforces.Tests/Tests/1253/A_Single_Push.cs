namespace Codeforces.Tests._1253;

internal class A_Single_Push
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1253.A_Single_Push.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            4
            6
            3 7 1 4 1 2
            3 7 3 6 3 2
            5
            1 1 1 1 1
            1 2 1 3 1
            2
            42 42
            42 42
            1
            7
            6
            
            """, """
            YES
            NO
            YES
            NO
            
            """);

        yield return new TestCaseData("""
            4
            3
            1 2 3
            998 999 1000
            3
            1 2 3
            2 3 5
            6
            1 1 1 1 1 1
            2 1 1 1 1 2
            6
            1 1 1 1 1 1
            1 1 1 1 1000 1

            """, """
            YES
            NO
            NO
            YES

            """);
    }
}
