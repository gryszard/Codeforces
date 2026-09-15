using BenchmarkDotNet.Attributes;
using Codeforces._0123;

namespace Codeforces.Utilities;

[MemoryDiagnoser]
public class Benchmark
{
    [Benchmark]
    public void Method()
    {
        using var @in = new StringReader("999999999 999999998 999999997 999999996 999999995 999999994");
        using var @out = new StringWriter();

        var solution = new B_Squares(@in, @out);
        solution.RunSolution();
    }
}