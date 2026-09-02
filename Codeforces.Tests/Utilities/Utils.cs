namespace Codeforces.Tests.Utilities;

internal class Utils
{
    internal static IEnumerable<TestCaseData> LoadExternalTestCases(string taskId, string taskName)
    {
        var inputFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "InputFiles", taskId, taskName);

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
