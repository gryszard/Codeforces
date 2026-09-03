namespace Codeforces.Tests.Utilities;

internal class Utils
{
    internal static IEnumerable<TestCaseData> LoadExternalTestCases(string taskId, string taskName, params string[] skipFiles)
    {
        var inputFilesDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "InputFiles", taskId, taskName);

        foreach (var file in Directory.GetFiles(inputFilesDirectory, "input*"))
        {
            Console.WriteLine(file);

            var expectedFile = file.Replace("input", "expected");

            var inputRawFileName = Path.GetFileNameWithoutExtension(file);

            if (skipFiles.Contains(inputRawFileName))
            {
                continue;
            }

            var input = File.ReadAllText(file);
            var expectedOutput = File.ReadAllText(expectedFile);

            yield return new TestCaseData(input, expectedOutput)
                .SetArgDisplayNames(inputRawFileName);
        }
    }
}
