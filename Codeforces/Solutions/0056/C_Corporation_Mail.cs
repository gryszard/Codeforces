using Codeforces.Utilities;

namespace Codeforces._0056;

public class C_Corporation_Mail(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var remainingDescription = FetchLine().AsSpan();

        var tokenSize = GetNextTokenSize(remainingDescription);
        var boss = new Employee();
        var currentEmployee = boss;

        while (tokenSize > 0)
        {
            ArgumentNullException.ThrowIfNull(currentEmployee);

            var token = remainingDescription[..tokenSize];
            remainingDescription = remainingDescription[tokenSize..];

            if (tokenSize == 1 && token[0] == '.')
            {
                currentEmployee = currentEmployee.Boss;
            }
            else if (tokenSize == 1 && (token[0] == ',' || token[0] == ':'))
            {
                var subordinate = new Employee
                {
                    Boss = currentEmployee
                };
                currentEmployee.Subordinates.Add(subordinate);
                currentEmployee = subordinate;
            }
            else
            {
                currentEmployee.Name = token.ToString();
            }

            tokenSize = GetNextTokenSize(remainingDescription);
        }

        var (_, uncomfy) = CheckUncomfySituations(boss);
        var uncomfySituations = uncomfy.Sum(u => u.Value);

        _textWriter.WriteLine(uncomfySituations);
    }

    private (Dictionary<string, int> Occurrences, Dictionary<string, int> Uncomfy) CheckUncomfySituations(Employee employee)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(employee.Name);

        var occurrences = new Dictionary<string, int>();
        var uncomfy = new Dictionary<string, int>();

        foreach (var subordinate in employee.Subordinates)
        {
            var (occTemp, uncomfyTemp) = CheckUncomfySituations(subordinate);

            occurrences = MergeDictionaries(occurrences, occTemp);
            uncomfy = MergeDictionaries(uncomfy, uncomfyTemp);
        }

        if (!occurrences.TryGetValue(employee.Name, out var valueCheck))
        {
            occurrences.Add(employee.Name, 1);
            return (occurrences, uncomfy);
        }

        if (!uncomfy.TryGetValue(employee.Name, out var valueUncomfy))
        {
            uncomfy.Add(employee.Name, valueCheck);
            occurrences[employee.Name] = valueCheck + 1;
            return (occurrences, uncomfy);
        }

        uncomfy[employee.Name] = valueUncomfy + valueCheck;
        occurrences[employee.Name] = valueCheck + 1;

        return (occurrences, uncomfy);
    }

    private static Dictionary<string, int> MergeDictionaries(Dictionary<string, int> result, Dictionary<string, int> check)
    {
        foreach (var key in check.Keys)
        {
            var otherValue = check[key];

            if (!result.TryGetValue(key, out int value))
            {
                result.Add(key, otherValue);
                continue;
            }

            result[key] = value + otherValue;
        }

        return result;
    }

    private static int GetNextTokenSize(ReadOnlySpan<char> description)
    {
        if (description.Length == 0)
        {
            return 0;
        }

        char[] specialChars = ['.', ':', ','];
        int index = 0;
        while (!specialChars.Contains(description[index]))
        {
            index++;
        }

        if (index == 0)
        {
            index = 1;
        }

        return index;
    }

    private class Employee
    {
        public string? Name { get; set; }
        public Employee? Boss { get; set; }
        public List<Employee> Subordinates { get; set; } = [];
    }
}
