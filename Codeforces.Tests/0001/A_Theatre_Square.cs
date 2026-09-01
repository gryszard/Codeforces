namespace Codeforces.Tests._0001;

internal class A_Theatre_Square
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0001.A_Theatre_Square.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("6 6 4", "4\r\n");
        yield return new TestCaseData("1 1 1", "1\r\n");
        yield return new TestCaseData("100 200 1", "20000\r\n");
        yield return new TestCaseData("4 4 4", "1\r\n");
        yield return new TestCaseData("9637842 254987 156", "101013570\r\n");
        yield return new TestCaseData($"{1e9} {1e9} 1", $"{(long)1e18}\r\n");
        yield return new TestCaseData($"{1e9} {1e9} {1e9}", $"1\r\n");
        yield return new TestCaseData($"{1e9} {1e9} {1e9 - 1}", $"4\r\n");
    }
}
