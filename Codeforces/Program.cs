using Codeforces.Utilities;
using Codeforces._1883.D_In_Love;

//var solution = new Codeforces._1883.D_In_Love.Solution(Console.In, Console.Out);
//solution.Run();

static BaseSolution solutionFactory(TextReader reader, TextWriter writer) => new Solution(reader, writer);
TestsCreator.PerformFullTests(solutionFactory);
