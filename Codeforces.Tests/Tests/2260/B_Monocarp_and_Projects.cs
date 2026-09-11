namespace Codeforces.Tests._2260;

internal class B_Monocarp_and_Projects
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2260.B_Monocarp_and_Projects(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            7
            1 1 1
            3 10 2
            3 8 6
            7 20 1
            10 25 100
            8 36 17
            1 999900 1000000000000
            
            """, """
            0
            4
            18
            6
            1425
            110
            999898177699820694

            """);

        yield return new TestCaseData("""
            6
            10 20 100
            100 299 100
            100 299 99
            100 299 98
            100 299 2
            100 299 1
            
            """, """
            990
            4950
            4950
            4949
            197
            99

            """);
    }
}
