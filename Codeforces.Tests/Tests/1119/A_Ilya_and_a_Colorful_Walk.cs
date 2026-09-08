namespace Codeforces.Tests._1119;

internal class A_Ilya_and_a_Colorful_Walk
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1119.A_Ilya_and_a_Colorful_Walk(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            5
            1 2 3 2 3
            
            """, """
            4

            """);

        yield return new TestCaseData("""
            3
            1 2 1
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            7
            1 1 3 1 1 1 1
            
            """, """
            4

            """);

        yield return new TestCaseData("""
            7
            1 1 1 1 3 1 1
            
            """, """
            4

            """);
    }
}
