namespace Codeforces.Tests._4A_Watermelon;

internal class Tests
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._4A_Watermelon.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData("1", "NO\r\n");
        yield return new TestCaseData("2", "NO\r\n");
        yield return new TestCaseData("3", "NO\r\n");
        yield return new TestCaseData("5", "NO\r\n");
        yield return new TestCaseData("71", "NO\r\n");
        yield return new TestCaseData("99", "NO\r\n");

        yield return new TestCaseData("4", "YES\r\n");
        yield return new TestCaseData("6", "YES\r\n");
        yield return new TestCaseData("8", "YES\r\n");
        yield return new TestCaseData("50", "YES\r\n");
        yield return new TestCaseData("100", "YES\r\n");

        yield return new TestCaseData("0", "ERROR\r\n");
        yield return new TestCaseData("-1", "ERROR\r\n");
        yield return new TestCaseData("101", "ERROR\r\n");
        yield return new TestCaseData(int.MinValue.ToString(), "ERROR\r\n");
        yield return new TestCaseData(int.MaxValue.ToString(), "ERROR\r\n");

        yield return new TestCaseData("42error", "ERROR\r\n");
        yield return new TestCaseData("not an integer", "ERROR\r\n");
        yield return new TestCaseData(string.Empty, "ERROR\r\n");
    }
}
