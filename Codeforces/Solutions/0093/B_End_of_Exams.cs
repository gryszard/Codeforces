using Codeforces.Utilities;

namespace Codeforces._0093;

public class B_End_of_Exams(TextReader textReader, TextWriter textWriter) : BaseSolution(textReader, textWriter)
{
    public override void RunSolution()
    {
        SingleTest();
    }

    private void SingleTest()
    {
        var (n, w, m) = FetchThreeInts();

        double cupVolume = (double)(n * w) / m;

        if (2 * n < m)
        {
            _textWriter.WriteLine("NO");
            return;
        }

        if (n < m)
        {
            double part = w - cupVolume;
            double ratio = w / part;
            int partsCountAsInt = (int)Math.Round(ratio, 6);

            double remaining = w - (partsCountAsInt * part);
            remaining = Math.Round(remaining, 6);
            if (remaining != 0)
            {
                _textWriter.WriteLine("NO");
                return;
            }
        }

        _textWriter.WriteLine("YES");

        var currentBottle = 1;
        double remainingInBottle = w;

        for (int i = 0; i < m; i++)
        {
            double remainingInCup = cupVolume;

            while (Math.Round(remainingInCup, 6) > 0)
            {
                if (Math.Round(remainingInBottle - remainingInCup, 6) > 0)
                {
                    _textWriter.WriteLine($"{currentBottle} {remainingInCup:0.000000}");
                    remainingInBottle -= remainingInCup;
                    remainingInCup = 0;
                }
                else if (Math.Round(remainingInBottle - remainingInCup, 6) == 0)
                {
                    _textWriter.WriteLine($"{currentBottle} {remainingInCup:0.000000}");

                    remainingInCup = 0;
                    remainingInBottle = w;
                    currentBottle++;
                }
                else
                {
                    _textWriter.Write($"{currentBottle} {remainingInBottle:0.000000} ");

                    remainingInCup -= remainingInBottle;
                    remainingInBottle = w;
                    currentBottle++;
                }
            }
        }
    }
}
