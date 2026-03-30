namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/6
    internal static class TestDay
    {
        public static void Run()
        {
            var lines = File.ReadAllLines("./Inputs/Test.txt");

            decimal answerSumPart2 = 0;
            decimal currentCalc = 0;
            char currentOp = ' ';
            for (int i = 0; i < lines[0].Length; i++)
            {
                //var numberStr = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}{lines[3][i]}";
                var numberStr = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}";

                if (!string.IsNullOrWhiteSpace(numberStr))
                {
                    var number = decimal.Parse(numberStr);

                    //if (lines[4][i] != ' ')
                    if (lines[3][i] != ' ')
                    {
                        currentOp = lines[3][i];
                        currentCalc = number;
                    }
                    else if (currentOp == '+')
                        currentCalc += number;
                    else
                        currentCalc *= number;
                }
                else
                {
                    //end of calc
                    Console.WriteLine(currentCalc);
                    answerSumPart2 += currentCalc;
                }
            }
            answerSumPart2 += currentCalc;

            Console.WriteLine("Part2: " + answerSumPart2);
        }
    }
}