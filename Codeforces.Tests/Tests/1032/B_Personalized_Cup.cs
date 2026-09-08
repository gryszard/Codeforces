namespace Codeforces.Tests._1032;

internal class B_Personalized_Cup
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1032.B_Personalized_Cup(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            tourist
            
            """, """
            1 7
            tourist

            """);

        yield return new TestCaseData("""
            MyNameIsLifeIAmForeverByYourSideMyNameIsLife
            
            """, """
            3 15
            MyNameIsLifeIAm
            ForeverByYourSi
            deMyNameIsLife*

            """);

        yield return new TestCaseData("""
            abcdefghijklmnopqrst
            
            """, """
            1 20
            abcdefghijklmnopqrst

            """);

        yield return new TestCaseData("""
            abcdefghijklmnopqrsta
            
            """, """
            2 11
            abcdefghijk
            lmnopqrsta*

            """);

        yield return new TestCaseData("""
            abcdefghijklmnopqrstabcdefghijklmnopqrstabcdefghijklmnopqrstabcdefghijklmnopqrsta
            
            """, """
            5 17
            abcdefghijklmnopq
            rstabcdefghijklm*
            nopqrstabcdefghi*
            jklmnopqrstabcde*
            fghijklmnopqrsta*

            """);

        yield return new TestCaseData("""
            abcdefghijklmnopqrstabcdefghijklmnopqrstabcdefghijklmnopqrstabcdefghijklmnopqrstabcdefghijklmnopqrst
            
            """, """
            5 20
            abcdefghijklmnopqrst
            abcdefghijklmnopqrst
            abcdefghijklmnopqrst
            abcdefghijklmnopqrst
            abcdefghijklmnopqrst

            """);
    }
}
