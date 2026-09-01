namespace Codeforces.Tests._0688;

internal class A_Opponents
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0688.A_Opponents.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            2 2
            10
            00
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            4 1
            0100
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            4 5
            1101
            1111
            0110
            1011
            1111
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            4 5
            1111
            1111
            1111
            1111
            1111
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            4 5
            0000
            0000
            0000
            0000
            0000
            
            """, """
            5

            """);
    }
}
