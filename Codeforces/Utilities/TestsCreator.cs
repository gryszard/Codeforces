namespace Codeforces.Utilities;

public class TestsCreator
{
    public static void PerformFullTests<T>(Func<TextReader, TextWriter, T> solutionFactory) where T : BaseSolution
    {
        RemoveOldTests();
        WriteRandomTests();
        WriteTestsWithExpectedOutputs();
        RunTests(solutionFactory);
    }

    public static void RemoveOldTests()
    {
        Console.WriteLine();
        Console.WriteLine("Removing old tests");

        foreach (var inputFile in Directory.EnumerateFiles("..", "input_*.txt"))
        {
            File.Delete(inputFile);
            Console.WriteLine($"File {Path.GetFileName(inputFile)} removed");
        }

        foreach (var inputFile in Directory.EnumerateFiles("..", "expected_*.txt"))
        {
            File.Delete(inputFile);
            Console.WriteLine($"File {Path.GetFileName(inputFile)} removed");
        }

        foreach (var inputFile in Directory.EnumerateFiles("..", "output_*.txt"))
        {
            File.Delete(inputFile);
            Console.WriteLine($"File {Path.GetFileName(inputFile)} removed");
        }
    }

    public static void WriteRandomTests()
    {
        Console.WriteLine();
        Console.WriteLine("Starting random tests population");

        WriteRandomTest(testId: 20, q: (int)1e5, valueLimit: 10, startRemovingIndex: 4);
        WriteRandomTest(testId: 21, q: (int)1e5, valueLimit: 100, startRemovingIndex: 4);
        WriteRandomTest(testId: 22, q: (int)1e5, valueLimit: (int)1e3, startRemovingIndex: 4);
        WriteRandomTest(testId: 23, q: (int)1e5, valueLimit: (int)1e9, startRemovingIndex: 2);
        WriteRandomTest(testId: 24, q: (int)1e5, valueLimit: (int)1e9, startRemovingIndex: 4);
        WriteRandomTest(testId: 25, q: (int)1e5, valueLimit: (int)1e9, startRemovingIndex: 6);
        WriteRandomTest(testId: 26, q: (int)1e5, valueLimit: (int)1e9, startRemovingIndex: 10);
        WriteRandomTest(testId: 27, q: (int)1e5, valueLimit: 4, startRemovingIndex: 20);
        WriteRandomTest(testId: 28, q: (int)1e5, valueLimit: 4, startRemovingIndex: (int)1e2);
        WriteRandomTest(testId: 29, q: (int)1e5, valueLimit: 4, startRemovingIndex: (int)1e3);
        WriteRandomTest(testId: 30, q: (int)1e5, valueLimit: 4, startRemovingIndex: (int)2e3);

        Console.WriteLine("All tests written");
    }

    private static void WriteRandomTest(int testId, int q, int valueLimit, int startRemovingIndex)
    {
        RandomInputFile(testId, q, valueLimit, startRemovingIndex);
    }

    private static void RandomInputFile(int testId, int q, int valueLimit, int startRemovingIndex)
    {
        using var fileStream = new FileStream($"..\\input_{testId}.txt", FileMode.CreateNew, FileAccess.Write);
        using var streamWriter = new StreamWriter(fileStream);

        streamWriter.WriteLine(q);

        var segments = new List<(int, int)>();

        for (int i = 1; i <= q; i++)
        {
            if (i > startRemovingIndex && i % 2 == 1)
            {
                var randomSegmentId = Random.Shared.Next(segments.Count);
                var segmentToRemove = segments[randomSegmentId];

                var left = segmentToRemove.Item1;
                var right = segmentToRemove.Item2;

                streamWriter.WriteLine($"- {left} {right}");

                segments.Remove(segmentToRemove);
            }
            else
            {
                var randomInt1 = Random.Shared.Next(valueLimit) + 1;
                var randomInt2 = Random.Shared.Next(valueLimit) + 1;

                var left = Math.Min(randomInt1, randomInt2);
                var right = Math.Max(randomInt1, randomInt2);

                streamWriter.WriteLine($"+ {left} {right}");

                segments.Add((left, right));
            }
        }

        Console.WriteLine($"File {Path.GetFileName(fileStream.Name)} created");
    }

    public static void WriteTestsWithExpectedOutputs()
    {
        Console.WriteLine();
        Console.WriteLine("Starting tests with expected outputs population");

        WriteTest(testId: 1, q: 1, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 2, q: 10, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 3, q: (int)1e2, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 4, q: (int)1e3, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 5, q: (int)1e4, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 6, q: (int)5e4, output: i => i == 1 ? "NO" : "YES");
        WriteTest(testId: 7, q: (int)1e5, output: i => i == 1 ? "NO" : "YES");

        Console.WriteLine("All tests written");
    }

    private static void WriteTest(int testId, int q, Func<int, string> output)
    {
        InputFile(testId, q);
        ExpectedFile(testId, q, output);
    }

    private static void InputFile(int testId, int q)
    {
        using var fileStream = new FileStream($"..\\input_{testId}.txt", FileMode.CreateNew, FileAccess.Write);
        using var streamWriter = new StreamWriter(fileStream);

        streamWriter.WriteLine(q);

        for (int i = 1; i <= q; i++)
        {
            streamWriter.WriteLine($"+ {i} {i}");
        }

        Console.WriteLine($"File {Path.GetFileName(fileStream.Name)} created");
    }

    private static void ExpectedFile(int testId, int q, Func<int, string> output)
    {
        using var fileStream = new FileStream($"..\\expected_{testId}.txt", FileMode.CreateNew, FileAccess.Write);
        using var streamWriter = new StreamWriter(fileStream);

        for (int i = 1; i <= q; i++)
        {
            streamWriter.WriteLine(output(i));
        }

        Console.WriteLine($"File {Path.GetFileName(fileStream.Name)} created");
    }

    public static void RunTests<T>(Func<TextReader, TextWriter, T> factory, string testFilesDirectory = "..\\") where T : BaseSolution
    {
        Console.WriteLine();
        Console.WriteLine($"Starting tests");

        var inputFiles = Directory.EnumerateFiles(testFilesDirectory, "input_*");

        foreach (var inputFile in inputFiles)
        {
            using var inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            using var inputReader = new StreamReader(inputFileStream);

            var outputFileName = inputFile.Replace("input_", "output_");

            using var outputFileStream = new FileStream(outputFileName, FileMode.CreateNew, FileAccess.Write);
            using var outputWriter = new StreamWriter(outputFileStream);

            var solution = factory(inputReader, outputWriter);
            solution.RunSolution();

            Console.WriteLine($"File {Path.GetFileName(inputFileStream.Name)} tested");
        }

        Console.WriteLine($"Done. All tests completed");
    }
}
