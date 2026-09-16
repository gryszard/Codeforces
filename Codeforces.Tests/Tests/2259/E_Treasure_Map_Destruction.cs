namespace Codeforces.Tests._2259;

internal class E_Treasure_Map_Destruction
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2259.E_Treasure_Map_Destruction(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            12
            5
            0 1 -1 -1 0
            3
            -1 0 2
            5
            -1 1 -1 1 -1
            5
            -1 -1 -1 -1 -1
            5
            -1 2 -1 3 -1
            7
            2 1 0 1 0 1 2
            1
            -1
            3
            1 -1 1
            1
            0
            4
            3 -1 -1 -1
            6
            -1 -1 0 -1 2 4
            10
            -1 1 -1 -1 1 1 -1 -1 2 -1
            
            """, """
            10101
            -1
            10101
            10000
            -1
            0010100
            1
            010
            1
            0001
            -1
            1011001000

            """);

        yield return new TestCaseData("""
            2
            3
            -1 1 1
            3
            -1 -1 1
            
            """, """
            -1
            010

            """);

        yield return new TestCaseData("""
            11
            3
            -1 -1 -1
            3
            1 -1 -1
            3
            1 1 0
            3
            1 1 -1
            3
            2 -1 1
            3
            -1 2 -1
            3
            1 -1 2
            3
            -1 -1 1
            3
            -1 1 1
            5
            3 -1 2 1 0
            5
            0 1 -1 2 3
            
            """, """
            100
            010
            -1
            -1
            -1
            -1
            -1
            010
            -1
            -1
            -1

            """);
    }
}
