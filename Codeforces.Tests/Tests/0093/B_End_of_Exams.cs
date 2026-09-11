namespace Codeforces.Tests._0093;

internal class B_End_of_Exams
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._0093.B_End_of_Exams(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            2 500 3
            
            """, """
            YES
            1 333.333333
            1 166.666667 2 166.666667
            2 333.333333

            """);

        yield return new TestCaseData("""
            4 100 5
            
            """, """
            YES
            1 80.000000
            1 20.000000 2 60.000000
            2 40.000000 3 40.000000
            3 60.000000 4 20.000000
            4 80.000000

            """);

        yield return new TestCaseData("""
            4 100 7
            
            """, """
            NO

            """);

        yield return new TestCaseData("""
            5 500 2
            
            """, """
            YES
            1 500.000000 2 500.000000 3 250.000000
            3 250.000000 4 500.000000 5 500.000000

            """);

        yield return new TestCaseData("""
            20 1000 30
            
            """, """
            YES
            1 666.666667
            1 333.333333 2 333.333333
            2 666.666667
            3 666.666667
            3 333.333333 4 333.333333
            4 666.666667
            5 666.666667
            5 333.333333 6 333.333333
            6 666.666667
            7 666.666667
            7 333.333333 8 333.333333
            8 666.666667
            9 666.666667
            9 333.333333 10 333.333333
            10 666.666667
            11 666.666667
            11 333.333333 12 333.333333
            12 666.666667
            13 666.666667
            13 333.333333 14 333.333333
            14 666.666667
            15 666.666667
            15 333.333333 16 333.333333
            16 666.666667
            17 666.666667
            17 333.333333 18 333.333333
            18 666.666667
            19 666.666667
            19 333.333333 20 333.333333
            20 666.666667

            """);
    }
}
