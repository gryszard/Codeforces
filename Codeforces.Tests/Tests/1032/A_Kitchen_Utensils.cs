namespace Codeforces.Tests._1032;

internal class A_Kitchen_Utensils
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1032.A_Kitchen_Utensils(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            5 2
            1 2 2 1 3
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            10 3
            1 3 3 1 3 5 5 5 5 100
            
            """, """
            14

            """);

        yield return new TestCaseData("""
            1 1
            1
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            1 100
            1
            
            """, """
            99

            """);

        yield return new TestCaseData("""
            10 1
            1 2 3 4 5 6 7 8 9 10
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            10 1
            1 2 3 4 5 6 7 8 9 9
            
            """, """
            8

            """);
    }
}
