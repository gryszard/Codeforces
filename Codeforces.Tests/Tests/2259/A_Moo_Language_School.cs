namespace Codeforces.Tests._2259;

internal class A_Moo_Language_School
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2259.A_Moo_Language_School(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            6
            8 2
            10011100
            5 1
            11111
            8 4
            01111110
            5 1
            00101
            4 4
            1101
            4 4
            1111
            
            """, """
            1
            5
            0
            2
            0
            1

            """);
    }
}
