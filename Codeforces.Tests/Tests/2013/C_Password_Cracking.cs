namespace Codeforces.Tests._2013;

internal class C_Password_Cracking
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2013.C_Password_Cracking(@in, @out);
        solution.RunSolution();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            4
            3

            1

            0

            1

            0

            0
            
            0

            4

            1

            1

            0

            0

            0

            0

            4

            1

            1

            0

            1

            0

            0

            0

            2

            1

            0

            0

            0

            """, """
            
            
            ? 1

            ? 11

            ? 01

            ? 101

            ? 001

            ? 011

            ! 010

            ? 1

            ? 11

            ? 111

            ? 011

            ? 111

            ? 1101

            ! 1100

            ? 1

            ? 11

            ? 111

            ? 011

            ? 1011

            ? 0011

            ? 0111

            ! 0110

            ? 1

            ? 11

            ? 01

            ? 11

            ! 10

            """);
    }
}
