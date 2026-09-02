namespace Codeforces.Tests._1371;

internal class C_A_Cookie_for_You
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1371.C_A_Cookie_for_You.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            6
            2 2 1 2
            0 100 0 1
            12 13 25 1
            27 83 14 25
            0 0 1 0
            1000000000000000000 1000000000000000000 1000000000000000000 1000000000000000000
            """, """
            Yes
            No
            No
            Yes
            No
            Yes
            
            """);

        yield return new TestCaseData("""
            7
            10 1 10 1
            10 1 9 2
            10 1 11 1
            0 0 1 0
            100 0 100 0
            0 100 100 0
            50 50 100 0
            """, """
            Yes
            No
            No
            No
            Yes
            Yes
            Yes
            
            """);
    }
}
