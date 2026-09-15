using Codeforces.Utilities;
using Codeforces._0123;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

var solution = new B_Squares(Console.In, Console.Out);
solution.RunSolution();

//static BaseSolution solutionFactory(TextReader reader, TextWriter writer) => new Solution(reader, writer);
//TestsCreator.PerformFullTests(solutionFactory);

//BenchmarkRunner.Run<Benchmark>();