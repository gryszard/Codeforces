namespace Codeforces.Tests._2158;

internal class B_Split
{
    [TestCaseSource(nameof(LoadExternalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._2158.B_Split.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadExternalCases()
    {
        var inputFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "2158", "InputFiles");

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
