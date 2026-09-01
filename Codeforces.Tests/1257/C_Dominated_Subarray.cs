namespace Codeforces.Tests._1257;

public class C_Dominated_Subarray
{
    [TestCaseSource(nameof(LoadCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1257.C_Dominated_Subarray.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadCases()
    {
        var inputFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "1257", "InputFiles");

        foreach (var file in Directory.GetFiles(inputFilesDirectory, "input*.txt"))
        {
            Console.WriteLine(file);

            var expectedFile = file.Replace("input", "expected");

            var input = File.ReadAllText(file);
            var expectedOutput = File.ReadAllText(expectedFile);

            yield return new TestCaseData(input, expectedOutput)
                .SetArgDisplayNames(Path.GetFileNameWithoutExtension(file));
        }
    }
}
