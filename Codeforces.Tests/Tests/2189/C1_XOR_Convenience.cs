namespace Codeforces.Tests._2189;

internal class C1_XOR_Convenience
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2189.C1_XOR_Convenience(@in, @out);
        solution.RunSolution();

        using var outputReader = new StringReader(@out.ToString());

        string? line;
        while ((line = outputReader.ReadLine()) is not null)
        {
            VerifySingleLine(line);
        }

        Assert.Pass();
    }

    private static void VerifySingleLine(string line)
    {
        var permutation = line.Split(' ').Select(int.Parse).ToList();

        for (int i = 1; i < permutation.Count - 1; i++)
        {
            for (int j = permutation.Count - 1; j >= i; j--)
            {
                if (permutation[i] == (permutation[j] ^ (i + 1)))
                {
                    break;
                }

                if (j == i)
                {
                    Assert.Fail($"For permutation: {permutation[0]},...,{permutation[^2]},{permutation[^1]}, for i={i+1}, pi={permutation[i]} NO suitable pj found");
                    return;
                }
            }
        }
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            1
            200000

            """);

        yield return new TestCaseData("""
            10
            3
            4
            5
            6
            7
            8
            9
            10
            11
            12

            """);

        yield return new TestCaseData("""
            10
            199999
            199998
            199997
            199996
            199995
            199994
            199993
            199992
            199991
            199990

            """);
    }
}
