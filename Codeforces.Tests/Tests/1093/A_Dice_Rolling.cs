namespace Codeforces.Tests._1093;

internal class A_Dice_Rolling
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1093.A_Dice_Rolling.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("""
            4
            2
            13
            37
            100
            
            """, """
            1
            2
            6
            15

            """);
    }
}
