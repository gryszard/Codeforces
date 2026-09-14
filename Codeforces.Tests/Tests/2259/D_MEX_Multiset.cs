namespace Codeforces.Tests._2259;

internal class D_MEX_Multiset
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2259.D_MEX_Multiset(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            5
            6
            1 0 0 1 2 1
            4
            0 0 0 0
            3
            0 2 2
            4
            6 7 6 7
            5
            0 0 0 1 2
            
            """, """
            YES
            CABCCC
            YES
            ABBB
            NO
            YES
            CCCC
            YES
            ABBCC

            """);
    }
}
