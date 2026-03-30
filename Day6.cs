namespace AdventOfCode2025
{
    // https://adventofcode.com/2025/day/6
    internal static class Day6
    {
        public static void Run()
        {
            long answerSum = 0;

            var lines = File.ReadAllLines("./Inputs/Day6.txt");
            var nums1 = lines[0].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var nums2 = lines[1].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var nums3 = lines[2].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var nums4 = lines[3].Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            var op = lines[4].Replace(" ", "").ToCharArray();

            for (int i = 0; i < op.Length; i++)
            {
                long answer = 0;
                if (op[i] == '+')
                {
                    answer = nums1[i] + nums2[i] + nums3[i] + nums4[i];
                }
                else //if (op[i] == '*')
                {
                    answer = nums1[i] * nums2[i] * nums3[i] * nums4[i];
                }

                answerSum += answer;
            }

            Console.WriteLine("Part1: " + answerSum);

            decimal answerSumPart2 = 0;
            long currentCalc = 0;
            char currentOp = ' ';
            for (int i = 0; i < lines[0].Length; i++)
            {
                var numberStr = $"{lines[0][i]}{lines[1][i]}{lines[2][i]}{lines[3][i]}";

                if (!string.IsNullOrWhiteSpace(numberStr))
                {
                    var number = long.Parse(numberStr);

                    if (lines[4][i] != ' ')
                    {
                        currentOp = lines[4][i];
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
                    answerSumPart2 += currentCalc;
                }
            }

            //last calc
            answerSumPart2 += currentCalc;

            Console.WriteLine("Part2: " + answerSumPart2);
        }
    }
}