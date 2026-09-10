using Codeforces.Tests.Utilities;

namespace Codeforces.Tests._0056;

internal class C_Corporation_Mail
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0056.C_Corporation_Mail(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return Utils.OneLinerTest("MIKE:MAX.,ARTEM:MIKE..,DMITRY:DMITRY.,DMITRY...", "3");
        yield return Utils.OneLinerTest("A:A..", "1");
        yield return Utils.OneLinerTest("A:C:C:C:C.....", "6");
        yield return Utils.OneLinerTest("A:B:C:D:E.....", "0");
    }
}
