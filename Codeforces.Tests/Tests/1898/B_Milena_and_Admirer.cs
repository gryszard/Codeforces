namespace Codeforces.Tests._1898;

internal class B_Milena_and_Admirer
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1898.B_Milena_and_Admirer(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            4
            3
            1 3 2
            4
            1 2 3 4
            3
            3 2 1
            7
            1 4 4 3 5 7 6
            
            """, """
            1
            0
            3
            9

            """);

        yield return new TestCaseData("""
            7
            1
            10
            2
            10 20
            2
            10 10
            2
            9 4
            3
            1 100 3
            3
            1 100 5
            4
            1 1000 100 6
            
            """, """
            0
            0
            0
            2
            33
            19
            215

            """);

        yield return new TestCaseData("""
            1
            10
            1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1000000000 1
            
            """, """
            8999999991

            """);

        yield return new TestCaseData("""
            1
            3
            2 1 2
            
            """, """
            1

            """);
    }
}
