namespace Codeforces.Tests._1032;

internal class C_Playing_Piano
{
    [TestCaseSource(nameof(LoadLocalCases))]
    public void RunTest(string input, bool answerExists)
    {
        using var @in = new StringReader(input);
        using var @out = new StringWriter();

        var solution = new Codeforces._1032.C_Playing_Piano(@in, @out);
        solution.RunSolution();

        if (!answerExists)
        {
            Assert.That(@out.ToString(), Is.EqualTo("-1\r\n"));
            return;
        }

        using var outputReader = new StringReader(@out.ToString());
        using var inputReader = new StringReader(input);

        _ = inputReader.ReadLine();
        var inputKeyNumbers = inputReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(inputKeyNumbers);

        List<int> keyNumbers = [.. inputKeyNumbers.Split(' ').Select(int.Parse)];

        var outputFingering = outputReader.ReadLine();
        ArgumentException.ThrowIfNullOrWhiteSpace(outputFingering);

        List<int> fingering = [.. outputFingering.Split(' ').Select(int.Parse)];

        Assert.That(keyNumbers, Has.Count.EqualTo(fingering.Count));
        Assert.That(fingering, Has.All.InRange(1, 5));

        for (int i = 0; i < keyNumbers.Count - 1; i++)
        {
            if (keyNumbers[i] < keyNumbers[i + 1])
            {
                Assert.That(fingering[i], Is.LessThan(fingering[i + 1]),
                    message: $"i={i}, key[i]={keyNumbers[i]}, key[i+1]={keyNumbers[i + 1]}, fing[i]={fingering[i]}, fing[i+1]={fingering[i + 1]}");
                continue;
            }

            if (keyNumbers[i] > keyNumbers[i + 1])
            {
                Assert.That(fingering[i], Is.GreaterThan(fingering[i + 1]),
                    message: $"i={i}, key[i]={keyNumbers[i]}, key[i+1]={keyNumbers[i + 1]}, fing[i]={fingering[i]}, fing[i+1]={fingering[i + 1]}");
                continue;
            }

            Assert.That(fingering[i], Is.Not.EqualTo(fingering[i + 1]),
                message: $"i={i}, key[i]={keyNumbers[i]}, key[i+1]={keyNumbers[i + 1]}, fing[i]={fingering[i]}, fing[i+1]={fingering[i + 1]}");
        }
    }

    private static IEnumerable<TestCaseData> LoadLocalCases()
    {
        yield return new TestCaseData("""
            5
            1 1 4 2 2
            
            """, true);

        yield return new TestCaseData("""
            7
            1 5 7 8 10 3 1
            
            """, true);

        yield return new TestCaseData("""
            19
            3 3 7 9 8 8 8 8 7 7 7 7 5 3 3 3 3 8 8
            
            """, true);

        yield return new TestCaseData("""
            6
            1 2 3 4 5 6
            
            """, false);

        yield return new TestCaseData("""
            10
            1 2 3 4 5 5 4 3 2 1
            
            """, false);

        yield return new TestCaseData("""
            1
            1
            
            """, true);

        yield return new TestCaseData("""
            2
            1 2
            
            """, true);

        yield return new TestCaseData("""
            2
            2 1
            
            """, true);

        yield return new TestCaseData("""
            54
            1 2 1 2 3 2 1 2 3 4 3 2 1 2 3 4 5 4 3 2 1 1 2 3 4 4 3 2 1 1 1 2 3 4 5 5 5 4 3 2 1 1 1 1 1 1 1 1 1 1 2 3 4 5
            
            """, true);

        yield return new TestCaseData("""
            55
            1 2 1 2 3 2 1 2 3 4 3 2 1 2 3 4 5 4 3 2 1 1 2 3 5 5 4 3 2 1 1 1 2 3 4 5 5 5 4 3 2 1 1 1 1 1 1 1 1 1 1 2 3 4 5
            
            """, false);
    }
}
