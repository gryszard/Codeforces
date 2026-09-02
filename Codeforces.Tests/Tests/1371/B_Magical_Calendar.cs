namespace Codeforces.Tests._1371;

internal class B_Magical_Calendar
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1371.B_Magical_Calendar.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            5
            3 4
            3 2
            3 1
            13 7
            1010000 9999999
            
            """, """
            4
            3
            1
            28
            510049495001
            
            """);

        yield return new TestCaseData($"""
            5
            1 1
            2 1
            1 2
            {(int)1e9} {(int)1e9}
            {(int)1e9} {(int)(1e9 - 1)}
            """, $"""
            1
            1
            1
            499999999500000001
            499999999500000000
            
            """);
    }
}
