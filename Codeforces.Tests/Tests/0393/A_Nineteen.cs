namespace Codeforces.Tests._0393;

internal class A_Nineteen
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0393.A_Nineteen(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            nniinneetteeeenn
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            nneteenabcnneteenabcnneteenabcnneteenabcnneteenabcii
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            nineteenineteen
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            nneteennneteen
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            nineteennneteen
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            nineieennneieen
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            nineieennneteen
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            ninetennintnnintnint
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            ninetennintnnintninet
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            nneeeitieteeieteeietee
            
            """, """
            0

            """);

        yield return new TestCaseData("""
            nnneeeitieteeieteeietee
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            nnnneeeitieteeieteeietee
            
            """, """
            1

            """);

        yield return new TestCaseData("""
            nnnnneeeitieteeieteeietee
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            nnnnnneeeitieteeieteeietee
            
            """, """
            2

            """);

        yield return new TestCaseData("""
            nnnnnnneeeitieteeieteeietee
            
            """, """
            3

            """);
    }
}
