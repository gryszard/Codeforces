namespace Codeforces.Tests.TMPL;

internal class Template
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, string expectedOutput)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces.TMPL.Template.Solution(@in, @out);
        solution.Run();

        Assert.That(@out.ToString(), Is.EqualTo(expectedOutput));
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            input
            """, """
            ERROR

            """);
    }

    private static IEnumerable<TestCaseData> LoadExternalCases()
    {
        var inputFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "TMPL", "InputFiles");

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
