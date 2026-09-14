using Codeforces.Utilities;

namespace Codeforces._2259;

public class A_Moo_Language_School(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        RunTests(SingleTest);
    }

    private void SingleTest()
    {
        var (n, k) = FetchTwoInts();
        var s = FetchLine();
        var minimumTimesToPay = 0;

        for (int i = 0; i < n; i += k)
        {
            var limit = i + k;
            var hasToPay = true;

            for (int j = i; j < limit; j++)
            {
                hasToPay = hasToPay && (s[j] == '1');
            }

            if (hasToPay)
            {
                minimumTimesToPay++;
            }
        }

        _textWriter.WriteLine(minimumTimesToPay);
    }
}
