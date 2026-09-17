namespace Codeforces.Tests._2256;

internal class B_Domino_Tiles
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2256.B_Domino_Tiles(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            4
            2
            ??
            5
            0?1??
            5
            0?0??
            8
            00110011
            
            """, """
            4
            2
            0
            1

            """);

        yield return new TestCaseData("""
            11
            2
            ??
            2
            ?1
            2
            00
            3
            ???
            4
            ????
            8
            0???????
            8
            1???????
            8
            01??????
            8
            01100110
            8
            0?0?????
            8
            0???1???
            
            """, """
            4
            2
            1
            4
            4
            2
            2
            1
            1
            0
            0

            """);
    }
}
